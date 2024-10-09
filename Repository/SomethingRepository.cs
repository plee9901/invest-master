using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SomethingRepository : ISomethingRepository
    {
        private readonly ApplicationDBContext _context;
        public SomethingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Something> CreateAsync(Something somethingModel)
        {
            await _context.Somethings.AddAsync(somethingModel);
            await _context.SaveChangesAsync();
            return somethingModel;
        }

        public async Task<Something?> DeleteAsync(int id)
        {
            var somethingModel = await _context.Somethings.FirstOrDefaultAsync(s => s.Id == id);
            if (somethingModel == null)
            {
                return null;
            }
            _context.Somethings.Remove(somethingModel);
            await _context.SaveChangesAsync();
            return somethingModel;
        }

        public async Task<List<Something>> GetAllAsync()
        {
            return await _context.Somethings.ToListAsync();
        }

        public async Task<Something?> GetByIdAsync(int id)
        {
            return await _context.Somethings.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}