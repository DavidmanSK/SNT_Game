namespace Game.Interface
{
    public interface IWorldEntity
    {
        int Health { get; set; }
        int[] Location { get; set; }

        string GetInformation();
    }
}
