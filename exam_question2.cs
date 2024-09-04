using System;
using System.Collections.Generic;
using System.Linq;

public class MyGenericClass<T> where T : struct, IComparable<T>
{
    // Private generic collection
    private List<T> _collection;

    // Constructor
    public ValueCollection()
    {
        _collection = new List<T>();
    }

    // Method to add items to the private collection
    public void AddItem(T item)
    {
        _collection.Add(item);
    }

    // Method to return an item from the list by index
    public T GetItem(int index)
    {
        if (index < 0 || index >= _collection.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        return _collection[index];
    }

    // Method that returns a sorted collection with the items in descending order
    public List<T> GetSortedDescending()
    {
        return _collection.OrderByDescending(x => x).ToList();
    }
}
