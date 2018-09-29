using System;
using System.Threading;

namespace New_folder
{
    public class Spinner : IDisposable
    {
     private const string Sequence = @"............";
     private readonly int delay;
     private bool running;
     private readonly Thread thread;

     public Spinner()
     {
        this.delay = 100;
        thread = new Thread(Load);
     }

     public void Start()
     {
        running = true;
        if (!thread.IsAlive)
        {
           thread.Start();
        }
     }

     public void Stop()
     {
        running = false;
     }

     private void Load()
     {
        while (running)
        {
            var length = Sequence.Length;
            WriteChars(Sequence);
           
            Clear(length);
        }
     }

     private void Draw(char c)
     {
        Console.Write(c);
     }

     private void Clear(int length)
     {
         for(int i = 0;i < length; i ++)
         {
             Console.Write("\b \b");
             Thread.Sleep(delay);
         }
     }
    
     private void WriteChars(string seq)
     {
        for(int i = 0; i < seq.Length; i ++)
        {
            Draw(seq[i]);
            Thread.Sleep(delay);
        }
     }

     public void Dispose()
     {
        Stop();
     }
  }
}
