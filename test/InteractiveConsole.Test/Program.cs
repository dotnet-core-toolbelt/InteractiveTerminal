using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Oxygen;

namespace ConsoleApp5
{
    public class Program
    {


        public static void Main(string[] args)
        {
            
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


            InteractiveConsole console = new InteractiveConsole();

            console.Add(first);
            console.Add(second);
            console.Add(third);
            
            
            console.Run();


            var index = 1;
            foreach (var iteration in console.Iterations)
            {

                if (iteration.IsSelectable)
                {
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.SelectedStep.Title);
                }
                else
                {
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.InputValue);
                }
                index++;
            }


            Console.WriteLine("Press any key to exit...");
            Console.Read();

        }

        
    }


}