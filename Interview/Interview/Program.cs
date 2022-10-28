using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interview
{
    internal class Program
    {
        /// <summary>
        /// Here are the foods that are defined for eating.
        /// </summary>
        public enum Food
        {
            Berry,
            Cabbage,
            Carrot,
            Meat,
            Musaka,
        }
        /// <summary>
        /// Abstract class for inheritance from the different types of animals.
        /// </summary>
        public abstract class Animal
        {
            /// <summary>
            /// When the animal gets the right food, increases, when the animal gets the wrong food decreases; when it gets to 0, the animal dies.
            /// </summary>
            private int healthPoints;
            public int HealthPoints { get => healthPoints; protected set => healthPoints = value; }
            /// <summary>
            /// The name of the animal
            /// </summary>
            private string name;
            public string Name { get => name; protected set => name = value; }
            /// <summary>
            /// All of the right foods the animal can consume.
            /// </summary>
            private List<Food> food;
            public List<Food> Food { get => food; protected set => food = value; }
            public bool IsDead { get; protected set; } = false;
            /// <summary>
            /// Constructor for the class
            /// </summary>
            /// <param name="foods">Foods that the animal can consume</param>
            /// <param name="health points">Starting health points of the animal</param>
            /// <param name="name">Name of the animal</param>
            public Animal(List<Food> foods, int healthPoints, string name)
            {
                Food = foods;
                HealthPoints = healthPoints;
                Name = name;
            }
            /// <summary>
            /// This method is used when the health points of the animal get below 1, marks that the animal is dead, and prints it in the console
            /// </summary>
            public void Die()
            {
                IsDead = true;
                Console.WriteLine($"{name} has died.");
            }
            /// <summary>
            /// This method is used for feeding the animal, health points:
            /// increased, if the food is consumable
            /// decreased, if the food is not consumable
            /// </summary>
            /// <param name="food">The food that is given to the animal</param>
            public void Feed(Food food)
            {
                //Check if the animal is dead first
                if (this.IsDead)
                {
                    return;
                }
                //Checks if the food that is given is consumable
                if(IsConsumable(food))
                {
                    //Removed the ability to add health points when the food is the correct one, because it takes too much time for the animal to die.
                    //HealthPoints++;
                }
                else if(!IsConsumable(food)&&HealthPoints<=1)
                {
                    //If hit is below 1, the animal is marked as "dead".
                    HealthPoints--;
                    Die();
                }
                else
                {
                    //If health points are above 1, decrease them
                    HealthPoints--;
                }
            }

            /// <summary>
            /// Checks if the food is consumable for the animal
            /// </summary>
            /// <param name="food">The given food</param>
            /// <returns></returns>
            private bool IsConsumable(Food food)
            {
                foreach (Food currentFood in Food)
                {
                    if (currentFood == food)
                    {
                        return true;                         
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// A class for the animal rabbit
        /// </summary>
        public class Rabbit : Animal
        {
            public Rabbit(string name) : base(new List<Food>() { Program.Food.Berry, Program.Food.Carrot, Program.Food.Cabbage }, 5, name)
            {
            }
        }
        /// <summary>
        /// A class for the animal wolf
        /// </summary>
        public class Wolf : Animal
        {
            public Wolf(string name) : base(new List<Food>() { Program.Food.Meat, Program.Food.Musaka }, 10, name)
            {
            }
        }
        /// <summary>
        /// A class for the animal bear
        /// </summary>
        public class Bear : Animal
        {
            public Bear(string name) : base(new List<Food>() { Program.Food.Meat, Program.Food.Musaka, Program.Food.Berry }, 15, name)
            {
            }
        }
        static void Main(string[] args)
        {
            //Initialize heterogenous list of animals
            List<Animal> zoo = new List<Animal>
            {
                new Rabbit("Zayo"),
                new Rabbit("Bayo"),
                new Wolf("The big bad wolf"),
                new Bear("Winnie the Pooh")
            };
            //Feed all of the animals, until all of them die (kinda grim, I know)
            foreach (var animal in zoo)
            {
                while (!animal.IsDead)
                {
                    //Get random seed for each iteration of the loop and map it to food
                    var random = new Random(Guid.NewGuid().GetHashCode());
                    var foodNum = random.Next(0, 4);
                    animal.Feed((Food)foodNum);
                }
            }
        }
    }
}
