using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeResource.Terminal
{

    public class InteractiveConsole
    {

        private List<IQuestion> iterations;

        public IEnumerable<IQuestion> Iterations
        {
            get
            {
                return this.iterations;
            }
        }

        public InteractiveConsole()
        {
            this.iterations = new List<IQuestion>();
        }

        private int order = 0;
        public void Add(IQuestion iteration)
        {
            iteration.Order = this.order++;
            this.iterations.Add(iteration);
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

                if (iteration is IMultipleChoiceQuestion)
                {
                    (iteration as IMultipleChoiceQuestion).Print();

                    (iteration as IMultipleChoiceQuestion).PrintOptions();
                }
                else
                {

                    (iteration as IQuestion).Print();
                    continue;
                }



            }
        }
    }
}