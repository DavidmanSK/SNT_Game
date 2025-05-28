using Game.Enum;
using Game.Interface;

namespace Game.Entity
{
    internal class Character : WorldEntity, ICharacter
    {
        private string information;

        public CharacterType CharacterType { get; private set; }
        public bool IsFriendly { get; private set; }
        public string GreetingPhrase { get; private set; }

        public Character(IWorld world, CharacterType characterType, bool isFriendly, string greetingPhrase) : base(world)
        {
            information = "This is a character in the game world.";
            CharacterType = characterType;
            IsFriendly = isFriendly;
            GreetingPhrase = greetingPhrase;

        }

        public override string GetInformation()
        {
            return information;
        }

        public void Wave()
        {
            Console.WriteLine(GreetingPhrase);
        }
    }
}
