using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IRouletteService
    {
        Task<List<Roulette>> GetRoulettesAsync();
        Task<Roulette> GetRouletteByIdAsync(string id);
        Task PostRouletteAsync(Roulette roulette);
    }
}
