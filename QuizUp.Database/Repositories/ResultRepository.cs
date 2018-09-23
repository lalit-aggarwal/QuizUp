using Microsoft.EntityFrameworkCore;
using QuizUp.Models;
using QuizUp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizUp.Database.Repositories
{
    public class ResultRepository: IResultRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ResultRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddResultAsync(Result result)
        {
            try
            {
                var tracking = await _databaseContext.Results.AddAsync(result);
                bool isAdded = tracking.State == EntityState.Added;

                await _databaseContext.SaveChangesAsync();

                return isAdded;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateResultAsync(Result result)
        {
            try
            {
                var tracking = _databaseContext.Results.Update(result);
                bool isModified = tracking.State == EntityState.Modified;

                await _databaseContext.SaveChangesAsync();

                return isModified;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Result>> GetResultsByUserAsync(string userID)
        {
            try
            {
                var results = await _databaseContext.Results.ToListAsync();
                return results.Where(result => result.UserID.Equals(userID)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Result> GetLastResultByUsedAsync(string userID)
        {
            try
            {
                var results = await _databaseContext.Results.ToListAsync();
                return results.Where(result => result.UserID.Equals(userID)).Last();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
