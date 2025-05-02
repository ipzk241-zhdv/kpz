using mkr1.Command;
using mkr1.LightHTML;

Command();

static void LightHTML()
{
    var div = new LightElementNode("div");
    div.AddClass("container");

    var h1 = new LightElementNode("h1");
    h1.AddChild(new LightTextNode("Welcome to LightHTML"));

    var p = new LightElementNode("p");
    p.AddChild(new LightTextNode("This is a custom markup example."));

    var img = new LightElementNode("img", closing: ClosingType.SelfClosing);
    img.AddClass("responsive");

    div.AddChild(h1);
    div.AddChild(p);
    div.AddChild(img);

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