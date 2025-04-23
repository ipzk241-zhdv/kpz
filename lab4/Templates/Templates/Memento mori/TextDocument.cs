public class TextDocument
{
    private string _content;

    public TextDocument(string initialContent = "")
    {
        _content = initialContent;
    }

    public void Write(string text)
    {
        _content += text;
    }

    public void SetContent(string content)
    {
        _content = content;
    }

    public string GetContent() => _content;
}