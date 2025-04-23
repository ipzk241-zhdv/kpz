using System;

public interface IMemento
{
    Guid Id { get; }
    DateTime Date { get; }
}