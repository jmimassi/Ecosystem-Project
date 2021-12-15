﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Carnivore : Animal
    {
        int AttackPoint;

        protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed,int AttackPoint ,string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
                this.AttackPoint = AttackPoint; 
        }

        public void Attack(Herbivore proie)
        {
            proie.LoseHP(AttackPoint);
        }

        public  void Eat(Meat food)
        {
            this.EP += 5;
            // appeller DestroyObject

        }

        public virtual void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {

            int count = ListOfNearbyEntitiesForAnimal.Count; //2 listes une de viande, une d'hérbivore. 
            List<Meat> listOfNearbyMeat = new List<Meat>();
            List<Herbivore> listOfNearbyHerbivores = new List<Herbivore>();

            for (int i = 0; i < count; i++)
            {
                try {
                    
                    Meat meat = (Meat)ListOfNearbyEntitiesForAnimal[i];
                    listOfNearbyMeat.Add(meat);
                   
                }
                catch
                {
                    // cmt faire marcher ? ici tt est des entités
                }
                try
                {
                    Herbivore herbi = (Herbivore)ListOfNearbyEntitiesForAnimal[i];
                    listOfNearbyHerbivores.Add(herbi);
                }
                catch { }

                

                
            }

            if(listOfNearbyMeat.Count > 0)
            {
                int distancex = listOfNearbyMeat[0].x - this.x;
                int distancey = listOfNearbyMeat[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                   Eat(listOfNearbyMeat[0],sim);
                }
                else
                {
                    Move(listOfNearbyMeat[0]);
                }
            }

            else if (listOfNearbyHerbivores.Count > 0)
            {
                int distancex = listOfNearbyHerbivores[0].x - this.x;
                int distancey = listOfNearbyHerbivores[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if (Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    Attack(listOfNearbyHerbivores[0]);
                }
                else
                {
                    Move(listOfNearbyHerbivores[0]);
                }
            }



            else
            {
                Move(null);
            }

        }

        public void Eat(Meat meat, Simulation sim)
        {
            this.EP += 2;
            sim.DestroyObject(meat);
        }










        //protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, char Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        //{
        //}
    }
}
