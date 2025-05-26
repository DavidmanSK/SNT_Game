using Game.Classes;
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

        //Obsolete
        public IEnumerable<IWorldEntity> FindNearbySquare(int distance, Location currentLocation)
        {
            return worldEntities
                .Where(x => (x.Location.X >= currentLocation.X - distance && x.Location.X <= currentLocation.X + distance && x.Location.Y >= currentLocation.Y - distance && x.Location.Y <= currentLocation.Y + distance));
        }

        //Obsolete
        public IEnumerable<T> FindNearbySquare<T>(int distance, Location currentLocation) where T : IWorldEntity
        {
            return worldEntities.OfType<T>()
                .Where(x => (x.Location.X >= currentLocation.X - distance && x.Location.X <= currentLocation.X + distance && x.Location.Y >= currentLocation.Y - distance && x.Location.Y <= currentLocation.Y + distance));
        }

        public IEnumerable<IWorldEntity> FindNearby(int distance, Location currentLocation)
        {
            return worldEntities
                .Where(x => currentLocation.DistanceTo(x.Location) <= distance);
        }

        public IEnumerable<T> FindNearby<T>(int distance, Location currentLocation) where T : IWorldEntity
        {
            return worldEntities.OfType<T>()
                .Where(x => currentLocation.DistanceTo(x.Location) <= distance);
        }

        public List<IWorldEntity> GetAllEntities()
        {
            return worldEntities.ToList();
        }

        public IWorldEntity? GetEntityAt(Location location)
        {
            return worldEntities.Where(x => x.Location.X == location.X && x.Location.Y == location.Y).FirstOrDefault();
        }

        public void RemoveEntity(IWorldEntity entity)
        {
            worldEntities.Remove(entity);
        }
    }
}
