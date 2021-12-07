using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Измерение
{
    internal class Program
    {
        public static void Compare(List<ePoint> points, Random rnd, Stopwatch watch, StreamWriter writer)
        {
            for (int i = 0; i < 20000; i += 500)
            {
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Definition(points);
                watch.Stop();
                writer.Write(i + " " + watch.ElapsedMilliseconds);
                Console.Write(i + " " + watch.ElapsedMilliseconds);
                points.Clear();
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Andrew(points);
                watch.Stop();
                writer.WriteLine(" " + watch.ElapsedMilliseconds);
                Console.WriteLine(" " + watch.ElapsedMilliseconds);
                points.Clear();
            }
        }

        public static void Andrew(List<ePoint> points, Random rnd, Stopwatch watch, StreamWriter writer)
        {
            for (int i = 0; i < 200000; i += 500)
            {
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Andrew(points);
                watch.Stop();
                writer.WriteLine(i + " " + watch.ElapsedMilliseconds);
                Console.WriteLine(i + " " + watch.ElapsedMilliseconds);
                points.Clear();
            }
        }
        public static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("file.csv");
            Random rnd = new Random();
            Stopwatch watch = new Stopwatch();
            List<ePoint> points = new List<ePoint>();
            Compare(points,rnd,watch, writer);
            Console.WriteLine();
            Andrew(points, rnd, watch,writer);
            writer.Close();
        }
    }
}