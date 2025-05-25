namespace Game.Interface
{
    public interface IPlayer: IWorldEntity
    {
        string Name { get; }

        void Wave();

        void Blast(int[] location, int distance);
    }
}
