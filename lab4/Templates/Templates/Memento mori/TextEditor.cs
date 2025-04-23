public class TextEditor : IOriginator
{
    private readonly TextDocument _document;

    public TextEditor()
    {
        _document = new TextDocument();
    }

    public void Write(string text)
    {
        _document.Write(text);
    }

    public void Print()
    {
        Console.WriteLine(_document.GetContent());
    }

    public IMemento Save()
    {
        // створюємо Memento з поточним текстом
        return new Memento(_document.GetContent());
    }

    public void Restore(IMemento memento)
    {
        if (memento is Memento mem)
            _document.SetContent(mem.GetState());
        else
            throw new ArgumentException("Invalid memento type");
    }
}