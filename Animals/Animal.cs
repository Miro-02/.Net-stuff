using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Animals.Enums;

namespace Animals
{
    /// <summary>
    /// Abstract class for inheritance from the different types of animals.
    /// </summary>
    internal abstract class Animal
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
        private List<Enums.Food> food;
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
        private void Die()
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
            if (IsConsumable(food))
            {
                //Removed the ability to add health points when the food is the correct one, because it takes too much time for the animal to die.
                //HealthPoints++;
            }
            else if (!IsConsumable(food) && HealthPoints <= 1)
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
}
