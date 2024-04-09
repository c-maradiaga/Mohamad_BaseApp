using FormulaOne.DataService.Data;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories.Interfaces;

public class AchivementRepository : GenericRepository<Achivement>, IAchivementRepository
{
    public AchivementRepository(ILogger loger, AppDbContext context) : base(loger, context)
    {
    }

    
  public override async Task<IEnumerable<Achivement?>> GetAllAsync() 
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
         _logger!.LogError(e, "{Repo} AchivementRepository function error",  typeof(AchivementRepository));
         throw;
       }
    }

    public override async Task<bool> Delete(Guid id) 
    {
        try
        {
            // get the entity:
            var result = await _dbSet!.FirstOrDefaultAsync(x => x.Id == id);
            if(result is null) 
               return false;

            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (System.Exception e)
        {
            _logger!.LogError(e, "{Repo} Delete Achivemente function error", typeof(AchivementRepository));
            throw;
        }
    }

      public override async Task<bool> Update(Achivement achivement)
    {
        try 
        {
            //* get the entity:
            var result = await _dbSet!.FirstOrDefaultAsync(x => x.Id == achivement.Id);
            if (result == null) return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achivement.FastestLap;
            result.PolePosition = achivement.PolePosition;
            result.RaceWind = achivement.RaceWind;
            result.WorldChampionship = achivement.WorldChampionship;

            return true;
        
        }
        catch(Exception e)
        {
            _logger!.LogError(e, "{Repo} Update function error", typeof(AchivementRepository));
            return false;
        }

    }

    //? método "Custom", es decir, es un método aparte de los métodos del repositorio generíco
    public async Task<Achivement?> GetDriverAchivementAsyc(Guid driverId)
    {
        try
        {
            return await _dbSet!.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (System.Exception e)
        {
            _logger!.LogError(e, "{Repo} GetDriverAchivementAsyc function error", typeof(AchivementRepository));
            throw;
        }
    }

    
}