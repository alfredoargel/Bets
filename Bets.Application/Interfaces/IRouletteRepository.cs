using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IRouletteRepository
    {
        Task<List<Roulette>> GetAll();
        Task<Roulette> GetById(string id);
        Task Add(Roulette roulette);
        Task Update(string id, Roulette roulette);

    }
}
