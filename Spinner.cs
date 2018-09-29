using System;
using System.Threading;

namespace New_folder
{
    public interface ISpinner
    {
        void Start();
        void Stop();
    }
    public class Spinner : ISpinner, IDisposable
    {
     private const string Sequence = @"............";
        private readonly IWriter _writer;
        private readonly int delay;
     private bool running;
     private readonly Thread thread;

     public Spinner(IWriter writer)
     {
         _writer = writer;
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
         _writer.WriteChars(seq);
        // for(int i = 0; i < seq.Length; i ++)
        // {
        //     _writer.Draw(seq[i]);
        //     Thread.Sleep(delay);
        // }
     }

     public void Dispose()
     {
        Stop();
     }
  }
}
