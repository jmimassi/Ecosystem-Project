using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Herbivore : Animal
    {
        //protected Herbivore(int x, int y, int HP, int EP,int age,int VisionRadius,int ContactRadius, char Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, Sex)
        //{
        //}
        protected Herbivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
        }
    }
}
