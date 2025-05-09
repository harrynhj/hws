namespace day7;

public abstract class GenericRepository<T> : IRepository<T> where T : Entity
{
    private List<T> MyList {set; get;}

    public GenericRepository()
    {
        MyList = new List<T>();
    }

    public void Add(T item)
    {
        MyList.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return MyList.ToList();
    }

    public T GetById(int id)
    {
        foreach (var item in MyList)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }

    public void Remove(T item)
    {
        MyList.Remove(item);
    }

    public abstract void Save();
}