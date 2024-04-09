namespace FormulaOne.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers {get;}
    IAchivementRepository Achivements {get; }    

    Task CompleteAsync();
}