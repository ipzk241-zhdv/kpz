# Template Method
- Implemented `template method` in `LightNode` and `LightElementNode`
- Implemented life hooks:     
-- `OnCreated`  
-- `OnIserted/OnRemoved`  
-- `OnClassListApplied`  
-- `OnStylesApplied`  
-- `OnTextRendered`
- All hooks (at least, I believe) work with previously added features like `RenderState` or `AddClassCommand`

### Output examples:

Example fragment:  
```c#
== div.addChild(p) ==
LightElementNode class list applied!
LightElementNode styles were applied!
LightElementNode text rendered!
<div><p></p></div>

== p.addChild(text) ==
LightElementNode inserted with new child LightTextNode!
LightElementNode class list applied!
LightElementNode styles were applied!
LightTextNode class list applied!
LightTextNode styles were applied!
LightTextNode text rendered!
LightTextNode text rendered!
LightElementNode text rendered!
<div><p>Hello</p></div>
```

# State
- Implemented interface `IRenderState`  
- Implemented 3 state:     
-- `VisibleState` (display: block)    
-- `HiddenState` (display: none)    
-- `MinifiedState` (minified display without children)    
- `LightElementNode` dynamically defines its state and displays corresponding OuterHTML   

### Output examples:

Example fragment:  
```c#
var p = new LightElementNode("p");
p.AddChild(new LightTextNode("This is visible"));

var hiddenP = new LightElementNode("p");
hiddenP.AddChild(new LightTextNode("You won't see me!"));
hiddenP.SetRenderState(new HiddenState());

var minifiedDiv = new LightElementNode("div");
minifiedDiv.SetRenderState(new MinifiedState());
                                            
                                              output
Console.WriteLine(p.OuterHTML);            // <p>This is visible</p>
Console.WriteLine(hiddenP.OuterHTML);      // ""
Console.WriteLine(minifiedDiv.OuterHTML);  // <div/>
```

# Iterator
- Implemented interfaces `ILightIterator<T>` and `ILightAggregable<T>`  
- Implemented iterators:   
-- `DepthFirstIterator` (stack)  
-- `BreadthFirstIterator` (queue)  
- Method `GetIterator` in `LightElementNode` returns needed iterator for traversing children nodes.  

### Output examples:

Example fragment:   
```html
<div class="container">
    <h1>Some header text</h1>
    <p>Some paragraph text</p>
</div>
```

- DFS Output  
```html
<h1>Some header text</h1>
Some header text
<p>Some paragraph text</p>
Some paragraph text
```

- BFS Output  
```html
<h1>Some header text</h1>
<p>Some paragraph text</p>
Some header text
Some paragraph text
```

More complex example in outputExample.txt

# Command
- Implemented interface `ICommand` with `Execute()` and `Undo()` methods
- Implemented commands:  
-- `AddChildCommand`  
-- `AddClassCommand`  
- Implemented `CommandManager` for executing, canceling (`undo`) and `redo` commands  

### Examples:
 
```html
== div.addChild(p) ==
<div><p></p></div>

== p.addChild(text) ==
<div><p>Hello</p></div>

== ctrl + z, undo ==
<div><p></p></div>

== ctrl + y, redo ==
<div><p>Hello</p></div>
```