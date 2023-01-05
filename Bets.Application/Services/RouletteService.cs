using Bets.Application.Entities;
using Bets.Application.Enums;
using Bets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RouletteService(IRouletteRepository rouletteRepository, IUnitOfWork unitOfWork)
        {
            this._rouletteRepository = rouletteRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Roulette>> GetRoulettesAsync()
        {
            return await this._rouletteRepository.GetAll();
        }

        public async Task<Roulette> GetRouletteByIdAsync(string sid)
        {
            return await this._rouletteRepository.GetById(id: sid);
        }

        public async Task PostRouletteAsync(Roulette roulette)
        {
            await this._rouletteRepository.Add(roulette: roulette);
            await this._unitOfWork.Save();
        }
    }
}
