using mkr1.LightHTML;
using mkr1.Iterator;
using mkr1.Command;
using mkr1.State;
using mkr1.Visitor;

var root = GenerateRoot();
Visitor(root);
State();
Iterator(root);
Command();

static void Visitor(LightElementNode root)
{
    var parser = new HTMLParserVisitor();
    root.Accept(parser);
    Console.WriteLine($"== Root ==\n{root.OuterHTML}");
    Console.WriteLine("\n\n== Visitor CSS ==");
    Console.WriteLine(string.Join("\n", parser.Classes.ToArray()));
    Console.WriteLine("\n\n== Visitor texts ==");
    Console.WriteLine(string.Join("\n", parser.Texts.ToArray()));
}

static void State()
{
    var p = new LightElementNode("p");
    p.AddChild(new LightTextNode("This is visible"));

    var hiddenP = new LightElementNode("p");
    hiddenP.AddChild(new LightTextNode("You won't see me!"));
    hiddenP.SetRenderState(new HiddenState());

    var minifiedImg = new LightElementNode("img");
    minifiedImg.SetRenderState(new MinifiedState());

    var div = new LightElementNode("div");
    div.AddChild(p);
    div.AddChild(hiddenP);
    div.AddChild(minifiedImg);

    Console.WriteLine(div.OuterHTML);
}

static void Iterator(LightElementNode root)
{
    // DFS
    var dfs = root.GetIterator(IteratorType.DepthFirst);
    Console.WriteLine("==== DFS traversal ====");
    while (dfs.MoveNext())
    {
        Console.WriteLine(dfs.Current.OuterHTML);
    }

    // BFS
    var bfs = root.GetIterator(IteratorType.BreadthFirst);
    Console.WriteLine("\n\n\n===== BFS traversal ====");
    while (bfs.MoveNext())
    {
        Console.WriteLine(bfs.Current.OuterHTML);
    }
}

static LightElementNode GenerateRoot()
{
    var root = new LightElementNode("div");
    root.AddClass("container");

    var div = new LightElementNode("div");
    div.AddClass("small-container");

    var h1 = new LightElementNode("h1");
    h1.AddChild(new LightTextNode("Welcome to LightHTML"));

    var p = new LightElementNode("p");
    p.AddChild(new LightTextNode("This is a custom markup example."));

    var img = new LightElementNode("img", closing: ClosingType.SelfClosing);
    img.AddClass("responsive");

    div.AddChild(h1);
    div.AddChild(p);

    root.AddChild(div);
    root.AddChild(div);
    root.AddChild(div);

    return root;
}

static void Command()
{
    var div = new LightElementNode("div");
    var p = new LightElementNode("p");
    var text = new LightTextNode("Hello");

    var cmdManager = new CommandManager();
    cmdManager.ExecuteCommand(new AddChildCommand(div, p));
    Console.WriteLine("== div.addChild(p) ==");
    Console.WriteLine(div.OuterHTML);

    Console.WriteLine("\n== p.addChild(text) ==");
    cmdManager.ExecuteCommand(new AddChildCommand(p, text));
    Console.WriteLine(div.OuterHTML);

    Console.WriteLine("\n== ctrl + z, undo ==");
    cmdManager.Undo();
    Console.WriteLine(div.OuterHTML);

    Console.WriteLine("\n== ctrl + y, redo ==");
    cmdManager.Redo();
    Console.WriteLine(div.OuterHTML);
}