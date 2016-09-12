using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Program
    {

        public static void Show(List<string> list, int? item = null)
        {

            Console.Clear();

            List<Iteration> iterations = new List<Iteration>();

            Iteration first = new Iteration("What type of application do you want to create?");
            first.Steps.Add(new Step("Empty Web Application?"));
            first.Steps.Add(new Step("Console Application?"));
            first.Steps.Add(new Step("Web Application?"));
            first.Steps.Add(new Step("Web API Application?"));
            first.Steps.Add(new Step("Class Library?"));

            Iteration second = new Iteration("What kind of UI framework do you want?");
            second.Steps.Add(new Step("Bootstrap"));
            second.Steps.Add(new Step("Semantic UI"));


            Iteration third = new Iteration("What's the name of your application?");


            iterations.Add(first);
            iterations.Add(second);
            iterations.Add(third);


            foreach(var iteration in iterations){

                var defaultColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write( "? " );
                Console.ForegroundColor = defaultColor;

            }







            Console.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                //var padd = String.Concat(Enumerable.Repeat(" ", leftPadding));
                //var num = setNumber ? i + 1 + ". " : "";
                if (i == list.Count - 1)
                {
                    if (item == null || i + 1 != item)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    }
                    Console.Write(list[i]);
                }
                else
                {
                    if (item == null || i + 1 != item)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    }
                    Console.WriteLine(list[i]);


                }
            }
        }

        public static void Main(string[] args)
        {

            var list = new[] { "A", "B", "C", "D", "E" }.ToList();

            Show(list, 1);

            while (true)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    var item = Console.CursorTop;
                    Show(list, item);
                    Console.SetCursorPosition(3, item - 1);

                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    var item = Console.CursorTop;
                    if (item + 1 < list.Count)
                    {
                        Show(list, item + 2);
                        Console.SetCursorPosition(3, item + 1);
                    }
                }

            }

        }
    }
}
