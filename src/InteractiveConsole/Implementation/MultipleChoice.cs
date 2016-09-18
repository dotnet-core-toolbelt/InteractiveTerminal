using System;
using System.Collections.Generic;

namespace LifeResource.Terminal
{


    public class MultipleChoice : IMultipleChoiceQuestion
    {


        private int order = 0;
        private List<IOption> _options;

        public MultipleChoice(string question)
        {
            this.Question = question;
            this._options = new List<IOption>();
        }


        public object Answer
        {
            get; set;
        }


        public IList<IOption> Options
        {
            get { return _options; }
        }

        public string Question
        {
            get; set;
        }

        public void Add(IOption option)
        {
            option.Order = this.order++;
            this._options.Add(option);
        }

        public void Print(bool repaint = false)
        {
            Console.WriteLine(this.Question + " ( use arrow keys ) ");
        }

        public void PrintOptions(int selectedId, bool isReshow)
        {


            if (isReshow)
            {
                var top = Console.CursorTop - this.Options.Count;
                Console.SetCursorPosition(0, top);
            }

            var counter = 0;
            var defaultColor = Console.ForegroundColor;

            foreach (var option in this.Options)
            {
                var isSelected = option.Order == selectedId;

                if (isSelected)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.Write(isSelected ? "> " : "  ");
                option.Print(isReshow);

                Console.ForegroundColor = defaultColor;

                counter++;
            }

            if (isReshow)
                return;

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedId--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedId++;
                        break;
                }

                if (selectedId >= this.Options.Count) selectedId = this.Options.Count - 1;
                if (selectedId < 0) selectedId = 0;

                if (info.Key == ConsoleKey.Enter)
                {
                    this.Answer = this.Options[selectedId];
                    break;
                }

                this.PrintOptions(selectedId, true);
            }

            this.Clear();
        }
        public int Order { get; set; }

        public void Clear()
        {

            int iterationNo = this.Order + 1;

            var startLine = Console.CursorTop - this.Options.Count - iterationNo;

            if (startLine < iterationNo) startLine = iterationNo;

            var endLine = startLine + this.Options.Count;

            for (var i = startLine; i < endLine; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new String(' ', Console.BufferWidth));
            }

            var top = Console.CursorTop - this.Options.Count + iterationNo - 1;

            if (top < iterationNo) top = iterationNo;

            Console.SetCursorPosition(0, top);
        }

       
    }


}