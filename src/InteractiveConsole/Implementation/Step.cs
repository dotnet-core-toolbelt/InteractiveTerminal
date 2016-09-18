using System;
using System.Collections.Generic;

namespace LifeResource.Terminal
{

    public class Choice : IOption
    {

        public string Title { get; set; }

        public int Order
        {
            get; set;
        }


        public Choice() : this("")
        {

        }

        public Choice(string title)
        {
            this.Title = title;

        }

        public void Print(bool repaint = false)
        {
            Console.WriteLine(this.Title);
        }
    }

}