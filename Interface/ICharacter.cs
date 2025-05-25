using Game.Enum;

namespace Game.Interface
{
    public interface ICharacter: IWorldEntity
    {
        CharacterType CharacterType { get; }
        bool IsFriendly { get; }
        string GreetingPhrase { get; }

        void Wave();
    }
}
