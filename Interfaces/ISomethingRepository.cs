using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ISomethingRepository
    {
        Task<List<Something>> GetAllAsync();
        Task<Something> CreateAsync(Something somethingModel); 
        Task<Something?> GetByIdAsync(int id);
        Task<Something?> DeleteAsync(int id);
        
    }
}