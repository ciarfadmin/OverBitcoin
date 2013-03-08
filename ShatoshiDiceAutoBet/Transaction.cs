using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitnet.Client;

namespace ShatoshiDiceAutoBet
{
    internal class Transaction
    {
        public string account;
        public string address;
        public string category;
        public string amount;
        public string fee;
        public string confirmations;
        public string blockhash;
        public string blockindex;
        public string blocktime;
        public string txid;
        public string time;
        public string timereceived;


        /// <summary>
        /// Give us the Address of a transaction
        /// </summary>
        /// <param name="bc"></param>
        /// <param name="idTransaction"></param>
        /// <returns></returns>
        internal static string GetSender(BitnetClient bc, string idTransaction)
        {
            string lResult = null;
            try
            {
                var rawTransaction = bc.GetRawTransaction(idTransaction);
                string txid = rawTransaction["vin"][0]["txid"].ToString();
                var raw = bc.GetRawTransaction(txid);
                lResult = raw["vout"][0]["scriptPubKey"]["addresses"][0].ToString();
            }
            catch { }

            return lResult;
        }
    }
}
