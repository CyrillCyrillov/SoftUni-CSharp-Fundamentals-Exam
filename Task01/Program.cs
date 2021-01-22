using System;
using System.Text;

namespace Task01_Problem
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            while (true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if(comand[0] == "Done")
                {
                    break;
                }

                string typeComand = comand[0];

                switch (typeComand)
                {
                    case "Change":
                        string charr = comand[1];
                        string replacement = comand[2];

                        text = text.Replace(charr, replacement);

                        Console.WriteLine(text);

                        break;

                    case "Includes":
                        string substring = comand[1];

                        if(text.Contains(substring))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }

                        break;

                    case "End":
                        string endString = comand[1];

                        if(text.Contains(endString))
                        {
                            string helpTempString = text.Remove(0, text.Length - endString.Length);
                            if(helpTempString == endString)
                            {
                                Console.WriteLine("True");
                            }
                            else
                            {
                                Console.WriteLine("False");
                            }
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }

                        break;

                    case "Uppercase":
                        text = text.ToUpper();

                        Console.WriteLine(text);

                        break;

                    case "FindIndex":
                        charr = comand[1];

                        int index = text.IndexOf(charr);

                        Console.WriteLine(index);

                        break;

                    case "Cut":
                        int startIndex = int.Parse(comand[1]);
                        int lenght = int.Parse(comand[2]);

                        text = text.Remove(0, startIndex);
                        text = text.Remove(lenght);

                        Console.WriteLine(text);

                        break;

                    default:
                        break;
                }



            }
        }
    }
}
