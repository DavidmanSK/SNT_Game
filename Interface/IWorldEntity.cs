using Game.Classes;

namespace Game.Interface
{
    public interface IWorldEntity
    {
        int Health { get; set; }
        Location Location { get; set; }

        string GetInformation();
    }
}
