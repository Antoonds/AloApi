using Alo.DTOs;
using Alo.Entities;
using Alo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Data
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;
        public RequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RequestDto> GetRequestByIdAsync(int requestId)
        {
            var req = await _context.Requests
                .Include(x => x.Requester)
                .SingleOrDefaultAsync(x => x.Id == requestId);

            return new RequestDto
            {
                Id = req.Id,
                RequesterId = req.RequesterId,
                StartDate = req.StartDate,
                StopDate = req.StopDate,
                Vergadering = req.Vergadering,
                Accepted = req.Accepted,
                RequesterName = req.Requester.UserName,
                RequesterTak = req.Requester.Tak

            };
        }

        public async Task<IEnumerable<RequestDto>> GetRequestsAsync()
        {            
            var requests =  await _context.Requests
                .Include(x => x.Requester)
                /*    .Where(d => d.StartDate < DateTime.Now)
                   .OrderBy(x => x.StartDate)*/
                .ToListAsync();

            return requests.Select(req => new RequestDto
            {
                Id = req.Id,
                RequesterId = req.RequesterId,
                StartDate = req.StartDate,
                StopDate = req.StopDate,
                Vergadering = req.Vergadering,
                Accepted = req.Accepted,
                RequesterName = req.Requester.UserName,
                RequesterTak = req.Requester.Tak
            });
        }

        public void AddRequest(Request request)
        {
            _context.Requests.Add(request);
        }

        public void DeleteRequest(Request request)
        {
            _context.Requests.Remove(request);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
