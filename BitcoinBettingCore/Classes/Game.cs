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
    }
}
