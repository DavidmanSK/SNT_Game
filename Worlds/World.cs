using Game.Interface;

namespace Game.Worlds
{
    public class World : IWorld
    {
        private List<IWorldEntity> worldEntities = new List<IWorldEntity>();

        public string Name { get; set; }
        public List<IPlayer> Players { get; set; }
        public List<IAnimal> Animals { get; set; }
        public List<ICharacter> Characters { get; set; }
        public DateTime Time { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public World(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;

            Players = new List<IPlayer>();
            Animals = new List<IAnimal>();
            Characters = new List<ICharacter>();
            Time = DateTime.Now;
        }

        public void CreateWorld(List<IWorldEntity> entities)
        {
            worldEntities = entities;

            foreach (IWorldEntity entity in entities)
            {
                AddEntity(entity);
            }
        }

        public void AddEntity(IWorldEntity entity)
        {
            switch (entity)
            {
                case IPlayer:
                    Players.Add((IPlayer)entity);
                    break;
                case IAnimal:
                    Animals.Add((IAnimal)entity);
                    break;
                case ICharacter:
                    Characters.Add((ICharacter)entity);
                    break;
                default:
                    throw new ArgumentException("Unknown entity type");
            }
        }

        public IEnumerable<IWorldEntity> FindNearby(int distance, int[] currentLocation)
        {
            return worldEntities.Where(x => (x.Location[0] <= currentLocation[0] + distance && x.Location[0] <= currentLocation[1] + distance)).ToList();
        }

        public IEnumerable<T> FindNearby<T>(int distance, int[] currentLocation) where T : IWorldEntity
        {
            return worldEntities.OfType<T>()
                .Where(x => (x.Location[0] <= currentLocation[0] + distance && x.Location[0] <= currentLocation[1] + distance)).ToList();
        }

        public List<IWorldEntity> GetAllEntities()
        {
            return worldEntities.ToList();
        }

        public IWorldEntity? GetEntityAt(int[] location)
        {
            return worldEntities.Where(x => x.Location[0] == location[0] && x.Location[1] == location[1]).FirstOrDefault();
        }

        public void RemoveEntity(IWorldEntity entity)
        {
            worldEntities.Remove(entity);
        }
    }
}
