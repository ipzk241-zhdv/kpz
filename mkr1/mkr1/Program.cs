using mkr1.LightHTML;
using mkr1.Iterator;
using mkr1.Command;

var root = GenerateRoot();
Iterator(root);
Command();

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