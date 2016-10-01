using System;
using InteractiveTerminal.Interface;

namespace InteractiveTerminal.Implementation
{

    public class SimpleQuestion : IQuestion
    {
        public int Order { get; set; }
        public SimpleQuestion(string question)
        {
            this.Question = question;
        }
        public object Answer
        {
            get; set;
        }

        public string Question
        {
            get; set;
        }

        public void Print(bool repaint = false)
        {
            Console.CursorVisible = true;
            Console.Write(this.Question + "  ");
            var value = Console.ReadLine();
            this.Answer = value;
            Console.CursorVisible = false;
            this.PrintAnswer();
        }

        public void PrintAnswer()
        {
            Console.CursorTop--;
            Console.CursorLeft = this.Question.Length + 4;
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(this.Answer.ToString());
            Console.ForegroundColor = defaultColor;
        }
    }
}