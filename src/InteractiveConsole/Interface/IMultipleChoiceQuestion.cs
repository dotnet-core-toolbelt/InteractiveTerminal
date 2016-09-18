using System.Collections.Generic;

namespace LifeResource.Terminal
{


    public interface IMultipleChoiceQuestion : IQuestion
    {
        IList<IOption> Options { get; }
        void PrintOptions(int selectedID = 0 ,bool isShow = false );

        void Add(IOption option);

        void Clear();

    }
}