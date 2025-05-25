
using Game.Entity;
using Game.Enum;
using Game.Interface;
using Game.Worlds;

namespace Game
{
    public static class Game
    {
        public static void Main(string[] args)
        {
            World world = new World("Minecraft", 100, 100);

            List<ICharacter> characters = new List<ICharacter>();
            List<IAnimal> animals = new List<IAnimal>();
            List<IPlayer> players = new List<IPlayer>();

            players.Add(new Player(world, "Steve"));

            characters.Add(new Character(world, CharacterType.Warrior, true, "Hello!"));
            characters.Add(new Character(world, CharacterType.Mage, false, "Greetings!"));
            characters.Add(new Character(world, CharacterType.Rogue, true, "Hey there!"));

            animals.Add(new Animal(world, AnimalType.Wolf, true));
            animals.Add(new Animal(world, AnimalType.Bear, false));
            animals.Add(new Animal(world, AnimalType.Eagle, true));
            animals.Add(new Animal(world, AnimalType.Snake, false));
            animals.Add(new Animal(world, AnimalType.Wolf, true));

            List<IWorldEntity> worldEntities = new List<IWorldEntity>();
            worldEntities.AddRange(players);
            worldEntities.AddRange(characters);
            worldEntities.AddRange(animals);

            world.CreateWorld(worldEntities);

            DateTime time = world.Time;
        }
    }
}