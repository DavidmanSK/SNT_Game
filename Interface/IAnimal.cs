using Game.Enum;

namespace Game.Interface
{
    public interface IAnimal: IWorldEntity
    {
        bool IsFriendly { get; }
        AnimalType AnimalType { get; }

        void Attack(IWorldEntity target);
    }
}
