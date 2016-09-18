using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LifeResource.Terminal;

namespace ConsoleApp5
{
    public class Program
    {


        public static void Main(string[] args)
        {

            MultipleChoice first = new MultipleChoice("What type of application do you want to create?");
            first.Add(new Step("Empty Web Application?"));
            first.Add(new Step("Console Application?"));
            first.Add(new Step("Web Application?"));
            first.Add(new Step("Web API Application?"));
            first.Add(new Step("Class Library?"));


            MultipleChoice second = new MultipleChoice("What kind of UI framework do you want?");
            second.Add(new Step("Bootstrap"));
            second.Add(new Step("Semantic UI"));


            SimpleQuestion third = new SimpleQuestion("What's the name of your application?");


            InteractiveConsole console = new InteractiveConsole();

            console.Add(first);
            console.Add(second);
            console.Add(third);


            console.Run();


            var index = 1;
            foreach (var iteration in console.Iterations)
            {

                if (iteration is IMultipleChoiceQuestion)
                {
                    Console.WriteLine($"Selected Step {index} is  : " + ( iteration.Answer as IOption ).Order);
                }
                else
                {
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.Answer);
                }
                index++;
            }


            Console.WriteLine("Press any key to exit...");
            Console.Read();

        }


    }


}