using AutoMapper;
using Bets.Application.Entities;
using Bets.WebApi.Dto;
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

            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();

            CreateMap<Bet, BetDto>();
            CreateMap<BetDto, Bet>();

            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
        }
    }

}
