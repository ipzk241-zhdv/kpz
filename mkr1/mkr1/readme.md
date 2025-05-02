# Iterator
- ����� ���������� `ILightIterator<T>` �� `ILightAggregable<T>`
- ��������� ��� ���������: 
-- `DepthFirstIterator` (����)
-- `BreadthFirstIterator` (�����)
- ����� `GetIterator` � `LightElementNode` ������� �������� �������� ��� ������ ������� �����.

### �������� ������:

�� ������� ���������
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

����� �������� ������� � outputExample.txt