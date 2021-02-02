using Bets.Application.Entities;
using Bets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
        {
            this._playerRepository = playerRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await this._playerRepository.GetAll();
        }

        public async Task<Player> GetPlayerByIdAsync(string id)
        {
            return await this._playerRepository.GetById(id: id);
        }

        public async Task PostPlayerAsync(Player player)
        {
            await this._playerRepository.Add(player: player);
            await this._unitOfWork.Save();
        }
        public async Task PutPlayerAsync(string id, Player player)
        {
            await this._playerRepository.Update(id: id, player: player);
            await this._unitOfWork.Save();
        }
        public async Task AddAmountToPlayerBalance(string playerId, decimal amount)
        {
            Player player = await this._playerRepository.GetById(id: playerId);
            player.Balance += amount;
            await this.PutPlayerAsync(id: playerId, player: player);
        }
    }
}
