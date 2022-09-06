using System;

namespace Delegetes_Nutshell_9_
{
    public delegate void Transformer(int par); 
    internal class Program
    {
        public static void HardWork(Transformer p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10); // Invoke delegate
                System.Threading.Thread.Sleep(100); // Simulate hard work
            }
        }
        public static void WriteProgressToConsole(int percentComplete)
        {
            Console.WriteLine(percentComplete);
        }
        static void  WriteProgressToFile(int percentComplete)
         => System.IO.File.WriteAllText("progress.txt",
         percentComplete.ToString());

        static void Main(string[] args)
        {
            Transformer t = WriteProgressToConsole;
            t += WriteProgressToFile;
            HardWork(t);
        }
    }
}
