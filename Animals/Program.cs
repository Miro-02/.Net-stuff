using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class Program
    {
        
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
                    animal.Feed((Enums.Food)foodNum);
                }
            }
        }
    }
}
