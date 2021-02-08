using Alo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Interfaces
{
    public interface IFillInRepository
    {
        Task<FillIn> GetFillInByIdAsync(int fillInId);
        Task<IEnumerable<FillIn>> GetFillInRequestsAsync();
        void AddFillIn(FillIn fillIn);
        void DeleteFillIn(FillIn fillIn);
        void Update(FillIn fillIn);
        Task<bool> SaveAllAsync();
    }
}
