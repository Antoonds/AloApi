using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IFillInRepository FillInRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
