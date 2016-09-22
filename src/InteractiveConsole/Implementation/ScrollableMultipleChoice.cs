using System;

namespace LifeResource.Terminal
{

    public class ScrollableMultipleChoice : MultipleChoice
    {

        private int _itemsToShow;
        public ScrollableMultipleChoice(string question, int itemsToShow) : base(question)
        {
            this._itemsToShow = itemsToShow;
        }

        private int currentIndex = 0;
        public override void PrintOptions(int selectedId, bool isReshow)
        {

            if (!isReshow)
                Console.WriteLine("--------------------------------------------------");

            if (isReshow)
            {
                var top = Console.CursorTop - this.ItemsToShow - 1;
                Console.SetCursorPosition(0, top);
            }

            var defaultColor = Console.ForegroundColor;

            var start = this.currentIndex;
            var end = this.currentIndex + this.ItemsToShow;

            if (end > this.Options.Count){
                
                start = this.Options.Count - this.ItemsToShow; 
                end = this.Options.Count;
            }

            for (var index = start; index < end; index++)
            {
                var option = this.Options[index];
                var isSelected = option.Order == this.currentIndex;

                if (isSelected)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.Write(isSelected ? "> " : "  ");
                option.Print(isReshow);

                Console.ForegroundColor = defaultColor;

            }


            Console.WriteLine("--------------------------------------------------");

            if (isReshow)
                return;

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedId--;
                        this.currentIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedId++;
                        this.currentIndex++;
                        break;
                }

                if (this.currentIndex < 0) this.currentIndex = 0;
                if( this.currentIndex >= this.Options.Count ) this.currentIndex--;

                if (selectedId >= this.ItemsToShow) selectedId = this.ItemsToShow - 1;
                if (selectedId < 0) selectedId = 0;

                if (info.Key == ConsoleKey.Enter)
                {
                    this.Answer = this.Options[this.currentIndex];
                    break;
                }

                this.PrintOptions(selectedId, true);
            }

            this.Clear();


        }


        public override int ItemsToShow
        {
            get
            {
                return this._itemsToShow;
            }
        }


        public override void Clear()
        {
            int iterationNo = this.Order + 1;

            var startLine = Console.CursorTop - this.Options.Count - iterationNo - 1;

            if (startLine < iterationNo) startLine = iterationNo;

            var endLine = startLine + this.Options.Count + 1;

            for (var i = startLine; i < endLine; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new String(' ', Console.BufferWidth));
            }

            // var top = Console.CursorTop - this.Options.Count + iterationNo - 1;

            // if (top < iterationNo) top = iterationNo;

            var top  = iterationNo;

            Console.SetCursorPosition(0, top);
        }

    }

}