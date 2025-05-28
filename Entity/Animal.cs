using Game.Classes;
using Game.Enum;
using Game.Interface;

namespace Game.Entity
{
    public class Animal : WorldEntity, IAnimal
    {
        private readonly IWorld _world;
        private string information;

        public bool IsFriendly { get; private set; }
        public AnimalType AnimalType { get; private set; }

        public Animal(IWorld world, AnimalType animalType, bool isFriendly) : base(world)
        {
            _world = world;

            AnimalType = animalType;
            IsFriendly = isFriendly;

            information = $"Animal Type: {animalType}, Is Friendly: {isFriendly}, InitialHealth: {Health}, Location: [{Location.X}, {Location.Y}]";
        }

        public void Attack(IWorldEntity target)
        {
            // do stuff
        }

        public override string GetInformation()
        {
            return information;
        }
    }
}
