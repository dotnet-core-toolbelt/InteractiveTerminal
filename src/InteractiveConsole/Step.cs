using System;
using System.Collections.Generic;

namespace LifeResource.Terminal
{

    public class Step : IOption
    {

        public string Title { get; set; }

        public int Order
        {
            get; set;
        }


        public Step() : this("")
        {

        }

        public Step(string title)
        {
            this.Title = title;

        }

        public void Print(bool repaint = false)
        {
            Console.WriteLine(this.Title);
        }
    }

}