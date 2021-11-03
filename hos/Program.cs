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
                    Console.WriteLine(a);
                    
                    int b = rnd.Next(6, 9);
                    Console.WriteLine(b);
                    if (miss(rnd.Next(0, 10)))
                    {
                        utesekH[i] = 0;

                    }
                    else if (critic(rnd.Next(0, 10))) 
                    {
                        utesekH[i] = 2 * b;
                        lifeVillain -= 2 * b;
                    }
                    else
                    {
                        lifeVillain -= b;
                        utesekH[i] = b;

                    }
                    if (miss(rnd.Next(0, 10))) 
                    {
                        utesekE[i] = 0;

                    }
                    else if (critic(rnd.Next(0, 10))) 
                    {
                        lifeHero -= 2 * a;
                        utesekE[i] = 2 * a;
                    }
                    else
                    {
                        lifeHero -= a;
                        utesekE[i] = a;
                    }

                    Console.WriteLine(lifeHero + " " + lifeVillain);
                    int hos = 0;
                    int ellenfel = 0;
                        while (hos == ellenfel)
                        {
                            hos = rnd.Next(0, 101);
                            ellenfel = rnd.Next(0, 101);
                            Console.WriteLine(hos + " " + ellenfel);


                            if (hos > ellenfel)
                            {
                                egyutt[2 * i] = utesekH[i];
                                egyutt[2 * i + 1] = utesekE[i];


                                if (veszitett(lifeVillain))
                                {
                                    Console.WriteLine("A hős nyert");
                                    isDead = true;

                           //     folytat=false;
                                }
                                else if (veszitett(lifeHero))
                                {
                                    Console.WriteLine("A hős kikapott");
                                  isDead = true;
                          //        folytat = false;
                                }
                                else if (i == 9)
                                {
                                    Console.WriteLine("Döntetlen");
                                    isDead = true;
                           //       folytat = false;
                                }


                            }
                            else
                            {
                                egyutt[2 * i] = utesekE[i];
                                egyutt[2 * i + 1] = utesekH[i];
                                if (veszitett(lifeHero))
                                {
                                    Console.WriteLine("A hős kikapott");
                                    isDead = true;
                             //     folytat = false;
                                   

                                }
                                else if (veszitett(lifeVillain))
                                {
                                    Console.WriteLine("A hős nyert");
                                    isDead = true;
                             //     folytat = false;

                             
                                }
                                else if (i == 9)
                                {
                                    Console.WriteLine("Döntetlen");
                                    isDead = true;
                           //       folytat = false;
                                }
                            }
                        }
                        

                     
                    }
                }

                for (int i = 0; i < utesekE.Length; i++) {

                    Console.Write(utesekE[i] + " ");
            }
                Console.WriteLine();
                for (int i = 0; i < utesekH.Length; i++)
                {
                    Console.Write(utesekH[i] + " ");

                }
                Console.WriteLine();
                for (int i = 0; i < egyutt.Length; i++)
                {
                    Console.Write(egyutt[i] + " , ");

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


        public static bool miss(int x)
        {
            if (x <= 1)
            {
                Console.WriteLine("Ez mellé ment");
                return true;
            }
            else
            {
                Console.WriteLine("Talált!");
                return false;
            }
        }
        public static bool critic(int x)
        {
            if (x <= 2)
            {
                Console.WriteLine("Kritikus");
                return true;

            }
            else
            {
                Console.WriteLine("Normál ütés");
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
                Console.WriteLine("Would you like to continue? (y/n)");
                x = Console.ReadLine();
             
            }
            return x;
        }
    }
}
