using Game.Interface;

namespace Game.Entity
{
    internal class Player : IWorldEntity, IPlayer
    {
        private readonly IWorld _world;
        private string information;

        public int Health { get; set; }
        public int[] Location { get; set; }
        public string Name { get; private set; }

        public Player(IWorld world, string name)
        {
            _world = world;

            Name = name;
            Health = 100;

            Random random = new();

            Location =
            [
                random.Next(0, _world.Width),
                random.Next(0, _world.Height)
            ];

            information = $"Player Name: {Name}, Initial Health: {Health}";
        }

        public string GetInformation()
        {
            return information;
        }

        public void Wave()
        {
            Console.WriteLine("Hey there!");
        }

        public void Blast(int[] location, int distance)
        {
            _world.FindNearby(distance, location)
                .ToList()
                .ForEach(entity =>
                {
                    if (entity != this)
                    {
                        entity.Health -= 1;

                        string entityDisplayName = entity switch
                        {
                            IPlayer => ((Player)entity).Name,
                            IAnimal => ((Animal)entity).AnimalType.ToString(),
                            ICharacter => ((Character)entity).CharacterType.ToString(),
                            _ => "Unknown"
                        };

                        Console.WriteLine($"{entityDisplayName} was hit! Remaining Health: {entity.Health}");
                    }
                });
        }
    }
}
