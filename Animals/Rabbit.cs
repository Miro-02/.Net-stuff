using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Animals.Enums;
using static Animals.Program;

namespace Animals
{
    /// <summary>
    /// A class for the animal rabbit
    /// </summary>
    internal class Rabbit : Animal
    {
        public Rabbit(string name) : base(new List<Food>() { Enums.Food.Berry, Enums.Food.Carrot, Enums.Food.Cabbage }, 5, name)
        {
        }
    }
}
