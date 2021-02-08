using Alo.Entities;
using Alo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alo.Data
{
    public class FillInRepository : IFillInRepository
    {
        private readonly DataContext _context;
        public FillInRepository(DataContext context)
        {
            _context = context;
        }

        public void AddFillIn(FillIn fillIn)
        {
            _context.FillIns.Add(fillIn);
        }

        public void DeleteFillIn(FillIn fillIn)
        {
            throw new NotImplementedException();
        }

        public async Task<FillIn> GetFillInByIdAsync(int fillInId)
        {
            return await _context.FillIns
                .Include(x => x.FillInRequester)
                .SingleOrDefaultAsync(x => x.Id == fillInId);
        }

        public async Task<IEnumerable<FillIn>> GetFillInRequestsAsync()
        {
            return await _context.FillIns
                .Include(b => b.FillInRequester)
                .Include(a => a.Filler)
                .Where(c => c.Accepted == false)
                .ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(FillIn fillIn)
        {
            _context.Entry(fillIn).State = EntityState.Modified;
        }

        
    }
}
