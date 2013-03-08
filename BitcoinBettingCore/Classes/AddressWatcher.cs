using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bitnet.Client;
using Newtonsoft.Json;

namespace BitcoinBettingCore.Classes
{
    internal class AddressWatcher
    {
        //Queue of transactions to be processed b de Wallet Manager
        private Queue<Transaction> queue = new Queue<Transaction>();
        internal Queue<Transaction> Queue
        {
            get { return queue; }
            set { queue = value; }
        }

        internal string AddressLabel { get { return game.Label; } }

        private Game game;
        internal Game Game
        {
            get { return game; }
            set { game = value; }
        }

        private BitnetClient bitnetClient;

        private bool run = true;
        private int threadDelay = 2000;
        private int lastTimeReceived = Int32.MaxValue;

        #region Constructor

        internal AddressWatcher(Game address)
        {
            this.bitnetClient = BitcoinDaemonManager.getBitcoinClient();
            this.game = address;
            lastTimeReceived = game.LastTimeReceived;
        }

        #endregion

        #region Internal Methods

        internal void start()
        {
            while (run)
            {
                getPendingTransactions();
                Thread.Sleep(threadDelay);
            }
        }

        internal void stop()
        {
            this.run = false;
        }

        #endregion

        #region Private Methods

        private void getPendingTransactions()
        {
            //List<Transaction> transactions = new List<Transaction>();
            var rawTransactions = bitnetClient.ListTransactions(this.game.Label, 1000);
            var g = from t in rawTransactions
                    where t["category"].ToString() == "receive" && (int)t["timereceived"] > lastTimeReceived //&& (string)t["txi"] != lastIdReceived 
                    orderby t["timereceived"]
                    select t;

            foreach (var t in g)
            {
                Transaction tran = JsonConvert.DeserializeObject<Transaction>(t.ToString());
                queue.Enqueue(tran);
                lastTimeReceived = Convert.ToInt32(tran.timereceived);
            }
        }

        #endregion

    }
}

