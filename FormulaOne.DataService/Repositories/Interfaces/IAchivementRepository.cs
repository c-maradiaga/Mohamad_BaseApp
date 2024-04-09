using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repositories.Interfaces;

public interface IAchivementRepository: IGenericRepository<Achivement>
{
    Task<Achivement?> GetDriverAchivementAsyc(Guid driverId);
}