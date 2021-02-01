using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
