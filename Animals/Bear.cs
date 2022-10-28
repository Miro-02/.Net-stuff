using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Animals.Enums;
namespace Animals
{
    /// <summary>
    /// A class for the animal bear
    /// </summary>
    internal class Bear:Animal
    {
        public Bear(string name) : base(new List<Food>() { Enums.Food.Meat, Enums.Food.Musaka, Enums.Food.Berry }, 15, name)
        {
        }
    }
}
