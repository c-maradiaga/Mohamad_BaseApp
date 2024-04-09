using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger loger, AppDbContext context) : base(loger, context)
    {
        // Queda vacio
    }

    public override async Task<IEnumerable<Driver?>> GetAllAsync() 
    {
       try
       {
         return await _dbSet!.Where(x => x.Status == 1)
                            .AsNoTracking()
                            .AsSplitQuery()
                            .OrderBy(x => x.AddedDate)
                            .ToListAsync();
       }
       catch (System.Exception e)
       {
         _logger!.LogError(e, "{Repo} All function error",  typeof(DriverRepository));
         throw;
       }
    }
    


}