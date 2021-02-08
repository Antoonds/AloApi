using Alo.DTOs;
using Alo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Interfaces
{
    public interface IRequestRepository
    {
        Task<RequestDto> GetRequestByIdAsync(int requestId);
        Task<IEnumerable<RequestDto>> GetRequestsAsync();
        void AddRequest(Request request);
        void DeleteRequest(Request request);
        Task<bool> SaveAllAsync();
    }
}
