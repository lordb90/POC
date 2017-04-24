using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterRealWorld
{
    public class Compound
    {
        protected float boilingPoint;
        protected float meltingPoint;
        protected float molecularWeight;
        protected float molecularFormula;

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: Unknown -------");
        }
    }
}
