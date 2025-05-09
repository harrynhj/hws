namespace day7;

public class MyList<T>
{
    private List<T> list { set; get; }
    
    public MyList(T value) {
        list = new List<T>();
        list.Add(value);
    }

    public MyList()
    {
        list = new List<T>();
    }

    public void Add(T value)
    {
        list.Add(value);
    }

    public T Remove(int index)
    {
        var value = list[index];
        list.RemoveAt(index);
        return value;
    }

    public bool Contains(T value)
    {
        return list.Contains(value);
    }

    public void Clear()
    {
        list.Clear();
    }

    public void InsertAt(T element, int index)
    {
        list.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        list.RemoveAt(index);
    }

    public T Find(int index)
    {
        return list[index];
    }


}