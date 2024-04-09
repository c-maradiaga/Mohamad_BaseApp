namespace FormulaOne.Entities.DbSet;

public class Achivement: BaseEntity
{
    public int RaceWind { get; set; }
    public int PolePosition { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverId { get; set; }

    public virtual Driver? Driver{ get; set; } = null;

}