using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Models
{
    public class RouletteDto
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public DateTime Created { get; set; }
        public Boolean Active { get; set; }
    }
}
