using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication;
using System.Security.Policy;
using AdventOfCode.Utilities;

namespace AdventOfCode._2021
{
    public class Day4 : BaseDay
    {

        public Day4() : base(4, 2021)
        {
            
        }

        public class Bingo
        {
            public bool active = true;
            public Bingo(List<List<int>> d)
            {
                data = new List<List<int>>();
                d.ForEach(x => data.Add(x));
            }
            
            public List<List<int>> data;

            public bool Check(HashSet<int> drawn)
            {
                bool win = false;

                for (int i = 0; i < data.Count; i++)
                {
                    bool col = true;
                    foreach (var row in data)
                    {
                        if (!drawn.Contains(row[i]))
                            col = false;
                    }

                    if (col)
                        return true;
                }

                foreach (var row in data)
                {
                    //row.ForEach(x => Console.Write($"{x},"));
                    //Console.WriteLine();
                    if (row.TrueForAll(x => drawn.Contains(x)))
                        return true;
                }
                
                return win;
            }

            public int Get(HashSet<int> drawn)
            {
                int sum = 0;
                foreach (var row in data)
                {
                    foreach (var num in row)
                    {
                        if (!drawn.Contains(num))
                            sum += num;
                    }
                }

                return sum;
            }
            
            
        }
        
        
        public override string SolvePartOne()
        {
            int output = 0;
            List<int> toDraw = new List<int>()
                {12,28,0,63,26,38,64,17,74,67,51,44,77,32,6,10,52,47,61,46,50,29,15,1,39,37,13,66,45,8,68,96,53,40,76,72,21,93,16,83,62,48,11,9,20,36,91,19,5,42,99,84,4,95,92,89,7,71,34,35,55,22,59,18,49,14,54,85,82,58,24,73,31,97,69,43,65,27,81,56,87,70,33,88,60,2,75,90,57,94,23,30,78,80,41,3,98,25,79,86};
            List<Bingo> bingos = new List<Bingo>();
            var lines = Input.Read();
            List<List<int>> d = new List<List<int>>();
            List<int> row = new List<int>();
            foreach (var line in lines) 
            {
                if (line.Length == 0)
                {
                    bingos.Add(new Bingo(d));
                    d = new List<List<int>>();
                }
                else
                {
                    row = new List<int>();
                    var l = line.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                    l.ToList().ForEach(x => row.Add(int.Parse(x)));
                    d.Add(row);
                }
                
            }
            bingos.Add(new Bingo(d));
            d = new List<List<int>>();

            HashSet<int> drawn = new HashSet<int>();
            foreach (var num in toDraw)
            {
                drawn.Add(num);
                Console.WriteLine(num);
                foreach (var bingo in bingos)
                {
                    if (bingo.Check(drawn) && bingos.Count == 1)
                    {
                        return $"{bingo.Get(drawn) * num}";
                    }
                    else if (bingo.Check(drawn))
                    {
                        bingo.active = false;
                    }
                }
                bingos = bingos.Where(x => x.active == true).ToList();
            }
            return $"xxx";
        }

        public override string SolvePartTwo()
        {
            int output = 0;

            return $"{output}";
        }
    }
}