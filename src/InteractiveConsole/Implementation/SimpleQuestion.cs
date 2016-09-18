using System;
using System.Collections.Generic;

namespace LifeResource.Terminal
{

public class SimpleQuestion : IQuestion
    {
        public int Order{get;set;}
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
        }
    }
}