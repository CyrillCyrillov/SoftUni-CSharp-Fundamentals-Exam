using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guestsInfo = new Dictionary<string, List<string>>();
            int unlikedMealsCoun = 0;

            while (true)
            {
                string[] comand = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

                if(comand[0].ToUpper() == "STOP")
                {
                    break;
                }

                string typeComand = comand[0];
                string guest = comand[1];
                string meal = comand[2];

                switch (typeComand.ToUpper())
                {
                    case "LIKE":
                        
                        if(guestsInfo.ContainsKey(guest))
                        {
                            if(!guestsInfo[guest].Contains(meal))
                            {
                                guestsInfo[guest].Add(meal);
                            }
                        }
                        else
                        {
                            guestsInfo.Add(guest, new List<string> {meal});
                        }
                        break;

                    case "UNLIKE":

                        if(guestsInfo.ContainsKey(guest))
                        {
                            if(guestsInfo[guest].Contains(meal))
                            {
                                guestsInfo[guest].Remove(meal);
                                Console.WriteLine($"{guest} doesn't like the {meal}.");
                                unlikedMealsCoun ++;
                            }
                            else
                            {
                                Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                        }
                        break;
                    
                    default:
                        break;
                }
            }

            foreach (var item in guestsInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"{item.Key}: ");
                if(item.Value.Count > 0)
                {
                    for (int i = 0; i <= item.Value.Count - 1; i++)
                    {
                        Console.Write(item.Value[i]);
                        if (i < item.Value.Count - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                }
                
                
                
                /*
                foreach (var meals in item.Value)
                {
                    Console.WriteLine(string.Join(", ", meals));
                }
                */
                //Console.WriteLine();
            }

            Console.WriteLine($"Unliked meals: {unlikedMealsCoun}");
        }
    }
}
