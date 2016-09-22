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
            first.Add(new Choice("Empty Web Application?"));
            first.Add(new Choice("Console Application?"));
            first.Add(new Choice("Web Application?"));
            first.Add(new Choice("Web API Application?"));
            first.Add(new Choice("Class Library?"));


            MultipleChoice second = new MultipleChoice("What kind of UI framework do you want?");
            second.Add(new Choice("Bootstrap"));
            second.Add(new Choice("Semantic UI"));


            SimpleQuestion third = new SimpleQuestion("What's the name of your application?");



            ScrollableMultipleChoice fourth = new ScrollableMultipleChoice("Which alphabet do you like?" , 2);
            fourth.Add(new Choice("A"));
            fourth.Add(new Choice("B"));
            fourth.Add(new Choice("C"));
            fourth.Add(new Choice("D"));
            fourth.Add(new Choice("E"));
            fourth.Add(new Choice("F"));


            InteractiveConsole console = new InteractiveConsole();

            console.Add(first);
            console.Add(third);
            console.Add(second);
            console.Add(fourth);


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