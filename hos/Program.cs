using System;

namespace hos
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            bool isDead = false;
            bool folytat = true;
            while (folytat)
            {
                int lifeHero = 60;
                int lifeVillain = 70;
                int[] utesekH = new int[10];
                int[] utesekE = new int[10];
                int[] egyutt = new int[20];
                isDead = false;
                for (int i = 0; i < 10; i++)
                {
                    if (!isDead) { 
                    int a = rnd.Next(5, 8);
                    Console.WriteLine("Hero will punch the villain with " + a);
                    
                    int b = rnd.Next(6, 9);
                    Console.WriteLine("Villain will punch the hero with " +b);
                    if (miss(rnd.Next(0, 10),"H"))
                    {
                        utesekH[i] = 0;

                    }
                    else if (critic(rnd.Next(0, 10),"H")) 
                    {
                        utesekH[i] = 2 * b;
                        lifeVillain -= 2 * b;
                    }
                    else
                    {
                        lifeVillain -= b;
                        utesekH[i] = b;

                    }
                    if (miss(rnd.Next(0, 10),"V")) 
                    {
                        utesekE[i] = 0;

                    }
                    else if (critic(rnd.Next(0, 10),"V")) 
                    {
                        lifeHero -= 2 * a;
                        utesekE[i] = 2 * a;
                    }
                    else
                    {
                        lifeHero -= a;
                        utesekE[i] = a;
                    }

                    Console.WriteLine("Hero's life: " +lifeHero + ", Villain's life: " + lifeVillain);
                    int hos = 0;
                    int ellenfel = 0;
                        Console.WriteLine("Who will punch first?Biggest number will start.");
                        while (hos == ellenfel)
                        {
                            hos = rnd.Next(0, 101);
                            ellenfel = rnd.Next(0, 101);
                            Console.WriteLine("Heros's number is: "+ hos + ", villain's number is: " +ellenfel);
                            

                            if (hos > ellenfel)
                            {
                                Console.WriteLine("Hero punhes first.");
                                egyutt[2 * i] = utesekH[i];
                                egyutt[2 * i + 1] = utesekE[i];


                                if (veszitett(lifeVillain))
                                {
                                    Console.WriteLine("Hero won");
                                    isDead = true;

                           //     folytat=false;
                                }
                                else if (veszitett(lifeHero))
                                {
                                    Console.WriteLine("Hero lost");
                                  isDead = true;
                          //        folytat = false;
                                }
                                else if (i == 9)
                                {
                                    Console.WriteLine("Draw");
                                    isDead = true;
                           //       folytat = false;
                                }


                            }
                            else
                            {
                                Console.WriteLine("Villain punches first.");
                                egyutt[2 * i] = utesekE[i];
                                egyutt[2 * i + 1] = utesekH[i];
                                if (veszitett(lifeHero))
                                {
                                    Console.WriteLine("Hero lost");
                                    isDead = true;
                             //     folytat = false;
                                   

                                }
                                else if (veszitett(lifeVillain))
                                {
                                    Console.WriteLine("Hero won");
                                    isDead = true;
                             //     folytat = false;

                             
                                }
                                else if (i == 9)
                                {
                                    Console.WriteLine("Draw");
                                    isDead = true;
                           //       folytat = false;
                                }
                            }
                        }
                        

                     
                    }
                }
                Console.WriteLine("Villain's punches: ");

                for (int i = 0; i < utesekE.Length; i++) {
                    
                    Console.Write(utesekE[i] + " ");
            }
                Console.WriteLine();
                Console.WriteLine("Hero's punches: ");
                for (int i = 0; i < utesekH.Length; i++)
                {
                    
                    Console.Write(utesekH[i] + " ");

                }
                Console.WriteLine();
                Console.WriteLine("the series of punches: ");
                for (int i = 0; i < egyutt.Length; i++)
                {
                   
                    Console.Write(egyutt[i] + "  ");

                }

                    string cont = folytatas("x");


                    if (cont == "n")
                    {
                        folytat = false;
                        
                    }
                    else if(cont == "y")
                    {
                    folytat = true;
                }

                
            }
            

















        }


        public static bool miss(int x, string who)
        {
            string y = who == "H" ? "Hero" : "Villain";
            if (x <= 1)
            {
                Console.WriteLine($"{y} missed the punch");
                return true;
            }
            else
            {
                Console.WriteLine($"{y} didn't miss the punch!");
                return false;
            }
        }
        public static bool critic(int x, string who)
        {
            String y = who == "H" ? "Hero" : "Villain";
            if (x <= 2)
            {
                Console.WriteLine($"{y} made a critical punch, counts double");
                return true;

            }
            else
            {
                Console.WriteLine($"{y} made a normal punch");
                return false;
            }
        }

        public static bool veszitett(int x)
        {
            if (x <= 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public static string folytatas(string x)
        {
            while (x != "y" && x != "n")
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to continue? (y/n)");
                x = Console.ReadLine();
             
            }
            return x;
        }
    }
}
