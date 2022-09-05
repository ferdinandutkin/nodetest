namespace nodetest.Models;

public class Vector2
{
    public int X {get; set; }
    public int Y { get; set; }

    public static Vector2 operator -(Vector2 vector, Vector2 anotherVector)
    {
        return new Vector2()
        {
            X = vector.X - anotherVector.X,
            Y = vector.Y - anotherVector.Y
        };
    }
    
    public static Vector2 operator +(Vector2 vector, Vector2 anotherVector)
    {
        return new Vector2()
        {
            X = vector.X + anotherVector.X,
            Y = vector.Y + anotherVector.Y
        };
    }
}