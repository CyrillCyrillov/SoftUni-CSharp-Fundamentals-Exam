using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(|@|\*)(?<text>[A-Z][a-z]{2,})(\1)(: {1})\[(?<f>[a-z]|[A-Z])\]\|\[(?<s>[a-z])\]\|\[(?<t>[a-z])\]\|$";

            Regex extractInfo = new Regex(pattern);

            int messagesNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= messagesNumber; i++)
            {
                string nextMessage = Console.ReadLine();

                MatchCollection decodedInfo = extractInfo.Matches(nextMessage);

                if(decodedInfo.Count == 0)
                {
                    Console.WriteLine("Valid message not found!");
                }
                else
                {
                    string textMessage = decodedInfo[0].Value.ToString();
                    textMessage = textMessage.Replace("*", "@");
                    int helpIndex = textMessage.IndexOf("@");
                    textMessage = textMessage.Remove(0, helpIndex);

                    textMessage = textMessage.Replace("@", "");
                    textMessage = textMessage.Replace(":", "");
                    textMessage = textMessage.Replace(" ", "");

                    helpIndex = textMessage.IndexOf("[");
                    int firstNumber = textMessage[helpIndex + 1];
                    int secondNumber = textMessage[helpIndex + 5];
                    int thirtNumber = textMessage[helpIndex + 9];
                    textMessage = textMessage.Remove(helpIndex);

                    
                    Console.WriteLine($"{textMessage}: {firstNumber} {secondNumber} {thirtNumber}");

                }
            }
        }
    }
}
