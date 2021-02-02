using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bets.Application.Entities
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RouletteId { get; set; }
        public decimal MaximunAmount { get; set; }
        public int? ResultNumber { get; set; }
        public int? ResultColor { get; set; }
        public Boolean Open { get; set; }
        public List<Bet> ListOfBets { get; set; }
    }
}
