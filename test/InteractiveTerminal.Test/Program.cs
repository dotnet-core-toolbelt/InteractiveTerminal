using System;
using InteractiveTerminal.Implementation;
using InteractiveTerminal.Interface;

namespace InteractiveTerminal.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.ReadLine();
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



            ScrollableMultipleChoice fourth = new ScrollableMultipleChoice("Which alphabet do you like?", 2);
            fourth.Add(new Choice("A"));
            fourth.Add(new Choice("B"));
            fourth.Add(new Choice("C"));
            fourth.Add(new Choice("D"));
            fourth.Add(new Choice("E"));
            fourth.Add(new Choice("F"));


            Terminal terminal = new Terminal();

            terminal.Add(first);
            terminal.Add(third);
            terminal.Add(second);
            terminal.Add(fourth);


            terminal.Run();


            var index = 1;
            foreach (var iteration in terminal.Iterations)
            {

                if (iteration is IMultipleChoiceQuestion)
                {
                    Console.WriteLine($"Selected Step {index} is  : " + (iteration.Answer as IOption).Order);
                }
                else
                {
                    Console.WriteLine($"Selected Step {index} is  : " + iteration.Answer);
                }
                index++;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

        }
    }
}
