# Iterator
- Додані інтерфейси `ILightIterator<T>` та `ILightAggregable<T>`
- Реалізовані два ітератори: 
-- `DepthFirstIterator` (стек)
-- `BreadthFirstIterator` (черга)
- Метод `GetIterator` у `LightElementNode` повертає потрібний ітератор для обходу дочірніх вузлів.

### Приклади виводу:

На прикладі фрагменту
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

Більш складний приклад в outputExample.txt