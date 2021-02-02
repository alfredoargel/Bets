using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(string id);
        Task PostPlayerAsync(Player player);
        Task PutPlayerAsync(string id, Player player);
        Task AddAmountToPlayerBalance(string playerId, decimal amount);
    }
}
