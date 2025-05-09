namespace day7;

public class MyStack<T>
{
    private Stack<T> Stack { set; get; }

    public MyStack()
    {
        Stack = new Stack<T>();
    }

    public MyStack(T value)
    {
        Stack = new Stack<T>();
        Stack.Push(value);
    }

    public int Count()
    {
        return Stack.Count;
    }

    public T Pop()
    {
        return Stack.Pop();
    }

    public void push(T value)
    {
        Stack.Push(value);
    }

}