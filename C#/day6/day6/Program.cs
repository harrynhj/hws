// See https://aka.ms/new-console-template for more information


using day6;
using day6.ColorBall;

// Methods
ReverseArray.Main([]);
Console.WriteLine($"Fib result: {FibonacciSeq.Fibonacci(8)}");
Console.WriteLine();


// Color Ball
Ball ball = new Ball(size:10,color:new Color(r:100,g:100,b:100));
for (int i = 0; i < 10; i++)
{
    ball.Throw();
}
ball.Pop();
for (int i = 0; i < 10; i++)
{
    ball.Throw();
}
Console.WriteLine(ball.GetCnt());