using Game.Classes;
using Game.Interface;

namespace Game.Entity
{
    internal class Player: WorldEntity, IPlayer
    {
        private readonly IWorld _world;

        private string information;

        public string Name { get; private set; }

        public Player(IWorld world, string name) : base(world)
        {
            _world = world;

            Name = name;

            information = $"Player Name: {Name}, Initial Health: {Health}";
        }

        public override string GetInformation()
        {
            return information;
        }

        public void Wave()
        {
            Console.WriteLine("Hey there!");
        }

        public void Blast(Location location, int distance)
        {
            _world.FindNearby(distance, location)
                .ToList()
                .ForEach(entity =>
                {
                    if (entity != this)
                    {
                        entity.Health -= 1;

                        Console.WriteLine($"{GetEntityDisplayName(entity)} was hit! Remaining Health: {entity.Health}");
                    }
                });
        }

        private string GetEntityDisplayName(IWorldEntity entity)
        {
            return entity switch
            {
                IPlayer => ((Player)entity).Name,
                IAnimal => ((Animal)entity).AnimalType.ToString(),
                ICharacter => ((Character)entity).CharacterType.ToString(),
                _ => "Unknown"
            };
        }
    }
}
