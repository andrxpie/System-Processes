﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThreadSync
{
    class Pair
    {
        public int a { get; set; }
        public int b { get; set; }
    }

    internal class Program
    {
        static string path1 = "C:\\Users\\dev.STEP\\source\\repos\\file1.txt";
        static string path2 = "C:\\Users\\dev.STEP\\source\\repos\\file2.txt";
        static string path3 = "C:\\Users\\dev.STEP\\source\\repos\\file3.txt";

        static void Main(string[] args)
        {
            //Semaphore sm = new Semaphore(3, 3);

            //for (int i = 0; i < 12; ++i)
            //    ThreadPool.QueueUserWorkItem(Method, sm);

            //Console.ReadKey();

            AutoResetEvent are = new AutoResetEvent(false);

            Task.Run(() => MethodGenerate(are));
            Task.Run(() => MethodAdd(are));
            Task.Run(() => MethodMultiply(are));

            Console.ReadKey();
        }

        static void MethodMultiply(object obj)
        {
            EventWaitHandle ev = (EventWaitHandle)obj;
            
            ev.WaitOne();
            var fs = new FileStream(path1, FileMode.Open, FileAccess.Read, FileShare.Read);

            List<Pair> pairs = JsonSerializer.Deserialize<List<Pair>>(fs);
            List<int> multiplyedPairs = new();

            foreach (var pair in pairs)
                multiplyedPairs.Add(pair.a * pair.b);

            string json = JsonSerializer.Serialize(multiplyedPairs, new JsonSerializerOptions { IncludeFields = true });
            Console.WriteLine(json);
            File.Create(path3).Close();
            File.WriteAllText(path3, json);

            ev.Set();
        }

        static void MethodAdd(object obj)
        {
            EventWaitHandle ev = (EventWaitHandle)obj;

            ev.WaitOne();
            var fs = new FileStream(path1, FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Pair> pairs = JsonSerializer.Deserialize<List<Pair>>(new StreamReader(fs).ReadToEnd());
            List<int> addedPairs = new();

            foreach (var pair in pairs)
                addedPairs.Add(pair.a + pair.b);

            string json = JsonSerializer.Serialize(addedPairs, new JsonSerializerOptions { IncludeFields = true });
            Console.WriteLine(json);
            File.Create(path2).Close();
            File.WriteAllText(path2, json);

            ev.Set();
        }
        
        static void MethodGenerate(object obj)
        {
            EventWaitHandle ev = (EventWaitHandle)obj;
            Random rnd = new Random();

            List<Pair> pairs = new();
            for (int i = 0; i < 10; i++)
                pairs.Add(new Pair { a = rnd.Next(1, 10), b = rnd.Next(1, 10)});

            string json = JsonSerializer.Serialize<List<Pair>>(pairs, new JsonSerializerOptions { IncludeFields = true });
            Console.WriteLine(json);
            File.Create(path1).Close();
            File.WriteAllText(path1, json);
            ev.Set();
        }

        static void Method(object obj)
        {
            Semaphore s = obj as Semaphore;

            bool stop = false;
            
            s.WaitOne();

            try
            {
                Random rnd = new Random();
                Console.Write("Id: {0} = ", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10; i++)
                    Console.Write(rnd.Next(1, 1000) + " ");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
            finally
            {
                stop = true;
                //Console.WriteLine("Thread {0} remove a lock", Thread.CurrentThread.ManagedThreadId);
                s.Release(); 
            }
        }
    }
}