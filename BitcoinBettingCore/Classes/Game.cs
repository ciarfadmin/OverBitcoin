using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace BitcoinBettingCore.Classes
{
    internal class Game
    {
        [BsonElement("_id"), BsonId]
        internal ObjectId Id { get; set; }
        [BsonElement("address")]
        internal string Address { get; set; }
        [BsonElement("label")]
        internal string Label { get; set; }
        [BsonElement("playDescription")]
        internal string PlayDescription { get; set; }
        [BsonElement("lastTimeReceived")]
        internal int LastTimeReceived { get; set; }
        [BsonElement("winOdds")]
        internal double WinOdds { get; set; }
        [BsonElement("priceMultiplier")]
        internal double PriceMultiplier { get; set; }
        [BsonElement("numberOfBets")]
        internal int NumberOfBets { get; set; }
        [BsonElement("btcWonByUs")]
        internal double BtcWonByUs { get; set; }
        [BsonElement("btcWonByPlayers")]
        internal double BtcWonByPlayers { get; set; }
        [BsonElement("winFee")]
        internal double WinFee { get; set; }


        internal double getBetResult(double betAmmount)
        {
            FastRandom rand = new FastRandom();

            double result = 0.00000001;
            double var = BtcWonByUs > 0 ? 0 : 0.1;
            if (rand.NextDouble() < WinOdds - var)
            { //Win
                result = betAmmount * PriceMultiplier - WinFee;
                BtcWonByUs -= result;
            }
            else
            {
                BtcWonByUs -= WinFee;
            }

            return result;
        }
    }
}
