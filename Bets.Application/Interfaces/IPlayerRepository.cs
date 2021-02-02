using Bets.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task Add(Player player);
        Task Update(string id, Player player);
    }
}
