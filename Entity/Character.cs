using Game.Classes;
using Game.Enum;
using Game.Interface;

namespace Game.Entity
{
    internal class Character : IWorldEntity, ICharacter
    {
        private readonly IWorld _world;
        private string information;

        public CharacterType CharacterType { get; private set; }
        public bool IsFriendly { get; private set; }
        public string GreetingPhrase { get; private set; }
        public int Health { get; set; }
        public Location Location { get; set; }

        public Character(IWorld world, CharacterType characterType, bool isFriendly, string greetingPhrase)
        {
            _world = world;

            information = "This is a character in the game world.";
            CharacterType = characterType;
            IsFriendly = isFriendly;
            GreetingPhrase = greetingPhrase;
            Health = 100;

            Random random = new();

            Location = new(
                random.Next(0, _world.Width),
                random.Next(0, _world.Height)
                );

        }

        public string GetInformation()
        {
            return information;
        }

        public void Wave()
        {
            //do stuff
        }
    }
}
