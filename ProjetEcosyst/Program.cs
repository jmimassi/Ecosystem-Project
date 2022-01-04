using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    class Program
    { 
        public static void Main(string[] args)
        {


          
            List<Entity> list = new List<Entity>();
            Console.WriteLine("Veuillez entrer le nombre d'ours souhaités : ");
            int ours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre de brebis souhaités : ");
            int brebis = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre d'herbes souhaités : ");
            int herbe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre d'updates de simulations souhaitées : ");
            int clock = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();  
            for (int i = 0; i < ours; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int sex = random.Next(0, 2);
                string sexe = "";
                if (sex == 0)
                {
                    sexe = "Male";
                }
                else if (sex == 1)
                {
                    sexe = "Femelle";
                }
                Ours ours1 = new Ours(x, y, 10, 10, 1, 7, 2, 3, 3, sexe);
                list.Add(ours1);
                
            }
            for (int i = 0; i < brebis; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int sex = random.Next(0, 2);
                string sexe = "";
                if (sex == 0)
                {
                    sexe = "Male";
                }
                else if (sex == 1)
                {
                    sexe = "Femelle";
                }
                Brebis breb1 = new Brebis(x, y, 5, 5, 1, 5, 1, 2, sexe);
                list.Add(breb1);

            }
            for (int i = 0; i < brebis; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                Herbe herb1 = new Herbe(x,y, 1, 1, 1, 2, 5);
                list.Add(herb1);
            }

                


            Simulation sim = new Simulation(list);

            
            while (clock > 0)
            {
                sim.Update(sim);
                Thread.Sleep(1500);
                clock--;
                Console.WriteLine("-----------------------------------------------------------------------------");
                

            }
        }
        

    }
}