using System.Collections.Generic;

namespace LifeResource.Terminal
{

 public interface IOption : IPrintable
    {
        int Order { get; set; }
        string Title { get; set; }
    }
}