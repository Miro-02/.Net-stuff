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
    /// A class for the animal wolf
    /// </summary>
    internal class Wolf : Animal
    {
        
        public Wolf(string name) : base(new List<Food>() { Enums.Food.Meat, Enums.Food.Musaka }, 10, name)
        {
        }
    }
}
