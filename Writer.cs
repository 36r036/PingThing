using System;
using System.Threading;

namespace New_folder
{
    public interface IWriter
    {
        void WriteChars(string seq);
    }
    public class Writer : IWriter
    {
        int _delay = 0;
        public Writer()
        {
            _delay = 100;
        }

        public void WriteChars(string seq)
        {
            for(int i = 0; i < seq.Length; i ++)
            {
                Draw(seq[i]);
                Thread.Sleep(_delay);
            }
        }

        private void Draw(char c)
        {
            Console.Write(c);
        }
    }
}
