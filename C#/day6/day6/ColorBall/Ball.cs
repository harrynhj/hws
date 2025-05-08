namespace day6.ColorBall;

public class Ball
{
    public int Size { get; set; }
    public Color Color { get; set; }
    public int Cnt { get; set; }

    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
        Cnt = 0;
    }

    public void Pop()
    {
        Size = 0;
    }
    
    public void Throw()
    {
        if (Size != 0)
        {
            Cnt++;
        }
    }

    public int GetCnt()
    {
        return Cnt;
    }

}