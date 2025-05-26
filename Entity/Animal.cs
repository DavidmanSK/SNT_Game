using Game.Classes;
using Game.Enum;
using Game.Interface;

namespace Game.Entity
{
    public class Animal : IWorldEntity, IAnimal
    {
        private readonly IWorld _world;
        private string information;

        public bool IsFriendly { get; private set; }
        public AnimalType AnimalType { get; private set; }
        public int Health { get; set; }
        public Location Location { get; set; }

        public Animal(IWorld world, AnimalType animalType, bool isFriendly)
        {
            _world = world;

            AnimalType = animalType;
            IsFriendly = isFriendly;
            Health = 100;

            Random random = new();

            Location = new(
                random.Next(0, _world.Width),
                random.Next(0, _world.Height)
                );

            information = $"Animal Type: {animalType}, Is Friendly: {isFriendly}, InitialHealth: {Health}, Location: [{Location.X}, {Location.Y}]";
        }

        public void Attack(IWorldEntity target)
        {
            // do stuff
        }

        public string GetInformation()
        {
            return information;
        }
    }
}
