using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeResource.Terminal
{

    public class InteractiveConsole
    {

        private List<Iteration> iterations;

        public IEnumerable<Iteration> Iterations
        {
            get
            {
                return this.iterations;
            }
        }

        public InteractiveConsole()
        {
            this.iterations = new List<Iteration>();
        }

        public void Add(Iteration iteration)
        {
            this.iterations.Add(iteration);
        }
        public void Add(params Iteration[] iterations)
        {
            this.iterations.AddRange(iterations);
        }


        public void Run()
        {

            Console.Clear();
            Console.CursorVisible = false;


            for (int iterationNo = 0; iterationNo < this.iterations.Count; iterationNo++)
            {
                var iteration = this.iterations[iterationNo];



                var defaultColor = Console.ForegroundColor;


                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("? ");
                Console.ForegroundColor = defaultColor;

                if (iteration.IsSelectable)
                {

                    Console.WriteLine(iteration.Question + " (use arrow keys) ");

                    var selectedId = 0;

                    printList(iteration, selectedId);

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

                        printList(iteration, selectedId, true);
                    }

                    clearIterations(iteration, iterationNo + 1);

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
        }

        private void clearIterations(Iteration iteration, int iterationNo)
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

        private void printList(Iteration iteration, int selected, bool isReshow = false)
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