namespace InteractiveTerminal.Interface
{
    public interface IOption : IPrintable
    {
        int Order { get; set; }
        string Title { get; set; }
    }
}