using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bitnet.Client;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json.Linq;

namespace BitcoinBettingCore.Classes
{
    internal class BettingManager
    {
        private AddressWatcher watcher;
        private bool run = true;
        private int threadDelay = 1000;
        private BitnetClient bitnetClient;
        private MongoCollection<Game> games;

        #region Constructor

        internal BettingManager(AddressWatcher watcher, MongoCollection<Game> games)
        {
            this.games = games;
            this.watcher = watcher;
            this.bitnetClient = BitcoinDaemonManager.getBitcoinClient();
        }

        #endregion

        #region Internal Methods

        internal void start()
        {
            while (run)
            {
                processPendingTransactions();
                Thread.Sleep(threadDelay);
            }
        }

        internal void stop()
        {
            this.run = false;
        }

        #endregion

        #region Private Methods

        private void processPendingTransactions()
        {
            while (watcher.Queue.Count != 0)
            {
                Transaction tr = watcher.Queue.Dequeue();
                string address = getSourceAddress(tr.txid);

                Console.WriteLine(tr.txid + " -- " + tr.amount);
                watcher.Game.LastTimeReceived = tr.timereceived;

                var query = Query.EQ("_id", watcher.Game.Id);
                var entity = games.FindOne(query);
                double prizeAmmount = entity.getBetResult(tr.amount);
                entity.LastTimeReceived = tr.timereceived;
                games.Save(entity);
                //Finally we send the prize ammount
                bitnetClient.SendFrom(watcher.AddressLabel, address, tr.amount, 0, "DICE BET");
            }
        }

        private string getSourceAddress(string transactionId)
        {
            List<string> addresses = new List<string>();
            var rawTransaction = bitnetClient.GetRawTransaction(transactionId);
            foreach (JObject input in rawTransaction["vin"])
            {
                var inputRawTx = bitnetClient.GetRawTransaction(input["txid"].ToString());
                int iv = (int)input["vout"];
                addresses.Add(inputRawTx["vout"][iv]["scriptPubKey"]["addresses"][0].ToString());
            }

            return addresses[0];
        }

        #endregion
    }
}
