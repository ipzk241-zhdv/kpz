using mkr1.LightHTML;

LightHTML();

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

    Console.WriteLine("== OuterHTML ==");
    Console.WriteLine(div.OuterHTML);
    Console.WriteLine();
    Console.WriteLine("== InnerHTML ==");
    Console.WriteLine(div.InnerHTML);
}