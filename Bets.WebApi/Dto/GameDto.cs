using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Dto
{
    public class GameDto
    {
        public string Id { get; set; }
        public string RouletteId { get; set; }
        public decimal MaximunAmount { get; set; }
        public int? ResultNumber { get; set; }
        public int? ResultColor { get; set; }
        public Boolean Open { get; set; }
        public List<BetDto> ListOfBets { get; set; }
    }
}
