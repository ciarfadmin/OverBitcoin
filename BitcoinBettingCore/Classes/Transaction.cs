using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitnet.Client;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitcoinBettingCore.Classes
{
    internal class Transaction
    {
        [BsonElement("_id"), BsonId]
        internal ObjectId Id { get; set; }
        [BsonElement("Account")]
        public string account { get; set; }
        [BsonElement("Account")]
        public string address { get; set; }
        [BsonElement("Account")]
        public string category { get; set; }
        [BsonElement("Account")]
        public float amount { get; set; }
        [BsonElement("Account")]
        public float fee { get; set; }
        [BsonElement("Account")]
        public int confirmations { get; set; }
        [BsonElement("Account")]
        public string blockhash { get; set; }
        [BsonElement("Account")]
        public int blockindex { get; set; }
        [BsonElement("Account")]
        public int blocktime { get; set; }
        [BsonElement("Account")]
        public string txid { get; set; }
        [BsonElement("txid")]
        public int time { get; set; }
        [BsonElement("time")]
        public int timereceived { get; set; }
        [BsonElement("timereceived")]

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
