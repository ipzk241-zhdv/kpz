# Iterator
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