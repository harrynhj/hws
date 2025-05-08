namespace day6.ColorBall;

public class Color
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    public byte A { get; set; }

    public Color(byte r, byte g, byte b, byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
        A = 255;
    }

    public Color(Color c)
    {
        R = c.R;
        G = c.G;
        B = c.B;
        A = c.A;
    }

    public int GetGreyScale()
    {
        return (R + G + B) / 3;
    }
}