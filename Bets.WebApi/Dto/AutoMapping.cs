using AutoMapper;
using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Roulette, RouletteDto>();
            CreateMap<RouletteDto, Roulette>();
        }
    }

}
