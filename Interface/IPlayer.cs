namespace Game.Interface
{
    public interface IPlayer: IWorldEntity
    {
        string Name { get; }

        void Wave();
    }
}
