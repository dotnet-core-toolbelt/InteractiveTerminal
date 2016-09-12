using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

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

            var iterationNo = 0;
            foreach (var iteration in iterations)
            {
                iterationNo++;

                var defaultColor = Console.ForegroundColor;


                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("? ");
                Console.ForegroundColor = defaultColor;

                if (iteration.IsSelectable)
                {

                    Console.WriteLine(iteration.Question + " (use arrow keys) ");

                    var selectedId = 0;

                    showList(iteration, selectedId);

                    while (true)
                    {
                        ConsoleKeyInfo info = Console.ReadKey();

                        switch (info.Key)
                        {
                            case ConsoleKey.UpArrow:
                                selectedId--;
                                break;
                            case ConsoleKey.DownArrow:
                                selectedId++;
                                break;
                        }

                        if (selectedId >= iteration.Steps.Count) selectedId = iteration.Steps.Count - 1;
                        if (selectedId < 0) selectedId = 0;

                        if (info.Key == ConsoleKey.Enter)
                        {
                            iteration.SelectedStep = iteration.Steps[selectedId];
                            break;
                        }

                        showList(iteration, selectedId, true);
                    }

                    clearIteration(iteration, iterationNo);

                }
                else
                {
                    Console.CursorVisible = true;
                    Console.Write(iteration.Question);
                    var value = Console.ReadLine();
                    iteration.InputValue = value;
                    Console.CursorVisible = false;
                    continue;
                }



            }


            var index = 1;
            foreach( var iteration in iterations ){

                if( iteration.IsSelectable ){
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.SelectedStep.Title);
                }
                else{
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.InputValue);
                }

            }


            Console.WriteLine("Press any key to exit...");
            Console.Read();

        }

        private static void clearIteration(Iteration iteration, int iterationNo)
        {
            var startLine = Console.CursorTop - iteration.Steps.Count - iterationNo;

            if (startLine < iterationNo) startLine = iterationNo;

            var endLine = startLine + iteration.Steps.Count;

            for (var i = startLine; i < endLine; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new String(' ', Console.BufferWidth));
            }

            var top = Console.CursorTop - iteration.Steps.Count + iterationNo - 1;

            if (top < iterationNo) top = iterationNo;

            Console.SetCursorPosition(0, top);

        }

        private static void showList(Iteration iteration, int selected, bool isReshow = false)
        {

            if (isReshow)
            {
                var top = Console.CursorTop - iteration.Steps.Count;
                Console.SetCursorPosition(0, top);
            }

            var counter = 0;
            var defaultColor = Console.ForegroundColor;

            foreach (var step in iteration.Steps)
            {
                if (counter == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine((counter == selected ? "> " : "  ") + step.Title);

                Console.ForegroundColor = defaultColor;
                counter++;
            }
        }
    }


}