﻿using Game.Classes;

namespace Game.Interface
{
    public interface IWorld
    {
        public string Name { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public List<IPlayer> Players { get; set; }
        public List<IAnimal> Animals { get; set; }
        public List<ICharacter> Characters { get; set; }

        DateTime Time { get ; set; }

        void CreateWorld(List<IWorldEntity> entities);
        IEnumerable<IWorldEntity> FindNearby(int distance, Location currentLocation);
        IEnumerable<T> FindNearby<T>(int distance, Location currentLocation) where T : IWorldEntity;

        IWorldEntity? GetEntityAt(Location location);
        void AddEntity(IWorldEntity entity);
        void RemoveEntity(IWorldEntity entity);
        List<IWorldEntity> GetAllEntities();
    }
}
