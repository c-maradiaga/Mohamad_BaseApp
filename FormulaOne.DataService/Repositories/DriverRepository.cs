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
    
    public override async Task<bool> Delete(Guid id)
    {
      try
      {
         // get my entity:
         var result = await _dbSet!.FirstOrDefaultAsync(x => x.Id == id);
         if (result == null)
            return false;

         result.Status = 0; //* para marcarlo como eliminado.
         result.UpdatedDate = DateTime.UtcNow;

         return true;

      }
      catch(Exception e) 
      {
        _logger!.LogError(e, "{Repo} Delete function error.", typeof(DriverRepository));
        return false;
      }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try 
        {
            //* get the entity:
            var result = await _dbSet!.FirstOrDefaultAsync(x => x.Id == driver.Id);
            if (result == null) return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.DriverNumber = driver.DriverNumber;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirth = driver.DateOfBirth;

            return true;
        
        }
        catch(Exception e)
        {
            _logger!.LogError(e, "{Repo} Update function error", typeof(DriverRepository));
            return false;
        }

    }
}