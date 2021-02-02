using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Dto
{
    public class PlayerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
