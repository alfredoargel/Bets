using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bets.Application.Entities
{
    public class Bet
    {
        public string PlayerId { get; set; }
        public decimal Amount { get; set; }
        public int? Number { get; set; }
        public int? Color { get; set; }
        public decimal? AmountEarned { get; set; }
    }
}
