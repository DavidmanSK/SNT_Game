using Game.Classes;
using Game.Interface;

namespace Game.Entity
{
    public abstract class WorldEntity : IWorldEntity
    {
        private readonly IWorld _world;

        public int Health { get; set; }
        public Location Location { get; set; }

        public abstract string GetInformation();

        public WorldEntity(IWorld world)
        {
            _world = world;

            Health = 100;

            Random random = new();

            Location = new(
                random.Next(0, _world.Width),
                random.Next(0, _world.Height)
                );
        }
    }
}
