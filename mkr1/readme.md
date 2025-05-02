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