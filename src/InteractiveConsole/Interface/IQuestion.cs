namespace InteractiveTerminal.Interface
{

  

    public interface IQuestion : IPrintable
    {
        int Order {get;set;}
        object Answer { get; set; }
        string Question { get; set; }
    }


   


}