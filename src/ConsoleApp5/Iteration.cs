using System.Collections.Generic;

namespace ConsoleApp5
{

    public class Iteration
    {


        public string Question { get; private set; }

        public IList<Step> Steps { get; set; }

        public Step SelectedStep{ get; set; }

        public string InputValue { get; set; }

        public bool IsSelectable
        {
            get
            {
                return this.Steps.Count > 0;
            }
        }

        public Iteration(string question)
        {

            this.Question = question;
            this.Steps = new List<Step>();
        }

    }
}