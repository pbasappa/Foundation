class SimpleOnes
{
    static void Main()
    {
        Console.WriteLine("Hello");
        
        int a = 4;
        int b = 3;
        Console.WriteLine("a " + a + " b " + b);
                
        SwapInPlace(a, b);
    }
    
    public static void SwapInPlace(int a, int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("a " + a + " b " + b);
    }
  }
