internal class Program
{
    private static readonly int waveLength = 40;
    private static readonly int amplitude = 10;

    private static void Main(string[] args)
    {
        Console.Clear();
        Console.CursorVisible = false;

        int windowWidth = 100;
        int windowHeight = 30;
#if WINDOWS
        try
        {
            Console.WindowWidth = windowWidth;
        }
        catch (PlatformNotSupportedException)
        {
        }
#endif

        while (true)
        {
            double time = (DateTime.Now - DateTime.Today).TotalSeconds;

            for (int x = 0; x < windowWidth; x++)
            {
                double y = amplitude * Math.Sin(2 * Math.PI * x / waveLength - time);

                int yPos = (int)(windowHeight / 2 + y);
                yPos = Math.Max(0, Math.Min(windowHeight - 1, yPos));

                Console.SetCursorPosition(x, yPos);
                Console.Write("*");
            }

            Thread.Sleep(100);
            ClearConsoleLine(0, windowHeight - 1);
        }
    }

    private static void ClearConsoleLine(int startX, int endX)
    {
        Console.SetCursorPosition(startX, Console.CursorTop);
        for (int i = startX; i <= endX; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(startX, Console.CursorTop);
    }
}