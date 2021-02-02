using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IGameService
    {
        Task PostGameAsync(Game game);
        Task AddBetToGameByRouletteIdAsync(string rouletteId, Bet bet);
        Task<Game> CloseGameByRouletteIdAsync(string rouletteId);
    }
}
