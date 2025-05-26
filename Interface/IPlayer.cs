using Game.Classes;

namespace Game.Interface
{
    public interface IPlayer: IWorldEntity
    {
        string Name { get; }

        void Wave();

        void Blast(Location location, int distance);
    }
}
