using System.Collections.Generic;

namespace LifeResource.Terminal
{

    public interface IPrintable
    {
        void Print(bool repaint = false);
    }

    public interface IQuestion : IPrintable
    {
        int Order {get;set;}
        object Answer { get; set; }
        string Question { get; set; }
    }


    public interface IOption : IPrintable
    {
        int Order { get; set; }
        string Title { get; set; }
    }

    public interface IMultipleChoiceQuestion : IQuestion
    {
        IList<IOption> Options { get; }
        void PrintOptions(int selectedID = 0 ,bool isShow = false );

        void Add(IOption option);

        void Clear();

    }


}