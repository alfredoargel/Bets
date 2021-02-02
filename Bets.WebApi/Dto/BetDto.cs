using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Dto
{
    public class BetDto
    {
        public string PlayerId { get; set; }
        public decimal Amount { get; set; }
        public int? Number { get; set; }
        public int? Color { get; set; }
        public int? AmountEarned { get; set; }
    }
}
