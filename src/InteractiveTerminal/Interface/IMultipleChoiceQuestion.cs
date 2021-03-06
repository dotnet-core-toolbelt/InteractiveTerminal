using System.Collections.Generic;

namespace InteractiveTerminal.Interface
{


    public interface IMultipleChoiceQuestion : IQuestion
    {

        int ItemsToShow{get;}

        IList<IOption> Options { get; }
        void PrintOptions(int selectedID = 0 ,bool isShow = false );
        void Add(IOption option);
        void Clear();

    }
}