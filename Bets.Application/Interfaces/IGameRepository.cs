using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetById(string id);
        Task<Game> GetOpenByRouletteId(string rouletteId);
        Task Add(Game game);
        Task Update(string id, Game game);
    }
}
