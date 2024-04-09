
using FormulaOne.DataService.Data;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories.Interfaces;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("Logs");

        Drivers = new DriverRepository(logger, _context);
        Achivements = new AchivementRepository(logger, _context);
    }


    public IDriverRepository Drivers {get;}
    public IAchivementRepository Achivements  {get;}

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    //? Garbage Collector:
    public void Dispose()
    {
        _context.Dispose();
    }
}