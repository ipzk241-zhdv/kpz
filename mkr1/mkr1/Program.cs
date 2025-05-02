using mkr1.Iterator;
using mkr1.LightHTML;

var root = GenerateRoot();
Iterator(root);

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
    div.AddChild(img);

    root.AddChild(div);
    root.AddChild(div);
    root.AddChild(div);

    return root;
}