using System.Collections.Generic;

namespace ConsoleApp5
{

    public class Step
    {

        public string Title { get; private set; }

        public IList<Step> Next { get; set; }


        public Step() : this("")
        {

        }

        public Step(string title)
        {
            this.Title = title;

            this.Next = new List<Step>();

        }


    }

}