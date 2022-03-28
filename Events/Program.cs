using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            EventExample ex = new EventExample();
            ex.OnKeyPressed += (_, c) => Console.WriteLine($"\n{c}");
            
            ex.Run();
        }
    }
    
    class EventExample
    {
        public EventHandler<char> OnKeyPressed;

        public void Run()
        {
            char key;
            while ((key = Console.ReadKey().KeyChar) != 'c')
            {
                OnKeyPressed?.Invoke(this, key);
            }
        }
    }
}

