using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 3)]
    public class Day03 : BaseDay
    {
        public override string PartOne(string input)
        {
            Coords startingLoc = new Coords(0,0);
            Map treeMap = new Map(CreateMap(input), startingLoc, 3, 1);
            Toboggan tob = new Toboggan(treeMap);

            return Convert.ToString(tob.DownhillRun());
        }

        public override string PartTwo(string input)
        {
            Coords startingLoc = new Coords(0,0);
            Map treeMap = new Map(CreateMap(input), startingLoc, 1, 1);
            Toboggan tob = new Toboggan(treeMap);

            var treeCount1 = tob.DownhillRun();

            tob.UpdateSlope(3,1);
            var treeCount2 = tob.DownhillRun();

            tob.UpdateSlope(5,1);
            var treeCount3 = tob.DownhillRun();

            tob.UpdateSlope(7,1);
            var treeCount4 = tob.DownhillRun();

            tob.UpdateSlope(1,2);
            var treeCount5 = tob.DownhillRun();

            return Convert.ToString(treeCount1 * treeCount2 * treeCount3 * treeCount4 * treeCount5);
        }

        public List<string> CreateMap(string input)
        {
            List<string> map = new List<string>();

            foreach (string line in input.Split("\n"))
            {
                map.Add(line.Split("\r")[0]);
            }

            return map;
        }

        public class Coords
        {
            public double x
            { get; set; }

            public double y
            { get; set; }

            public Coords(double x, double y)
            {
                this.x = x;

                this.y = y;
            }
        }

        public class Map
        {
            Coords loc;

            Coords moveModifiers;

            List<string> graph;

            public Map(List<string> graph, Coords startingLoc, Coords moveModifiers)
            {
                this.graph = graph;

                this.loc = startingLoc;

                this.moveModifiers = moveModifiers;
            }

            public Map(List<string> graph, Coords startingLoc, double x, double y)
            {
                this.graph = graph;

                this.loc = startingLoc;

                this.moveModifiers = new Coords(x,y);
            }

            public void Reset()
            {
                this.loc.x = 0;

                this.loc.y = 0;
            }

            public void UpdateModifiers(double x, double y)
            {
                this.moveModifiers.x = x;

                this.moveModifiers.y = y;
            }

            public void Move()
            {
                var xLoc = (this.loc.x + (1 * this.moveModifiers.x)) % (this.MapXDistance() + 1);

                this.loc.x = xLoc;

                var yLoc = (this.loc.y + (1 * this.moveModifiers.y));

                if (yLoc > this.MapYDistance())
                {
                    this.loc.y = this.MapYDistance();
                }
                else
                {
                    this.loc.y = yLoc;
                }
            }

            public double MapXDistance()
            {
                return graph[0].Length - 1;
            }

            public double MapYDistance()
            {
                return graph.Count - 1;
            }

            public string CurrSymbol()
            {
                return Convert.ToString(graph[Convert.ToInt32(this.loc.y)][Convert.ToInt32(this.loc.x)]);
            }

            public bool AtBottom()
            {
                return this.loc.y == MapYDistance();
            }
        }

        public class Toboggan
        {
            Map treeMap;

            public Toboggan(Map treeMap)
            {
                this.treeMap = treeMap;
            }

            public void UpdateSlope(double x, double y)
            {
                this.treeMap.UpdateModifiers(x, y);
            }

            public double DownhillRun()
            {
                double treeCount = 0;
                while (!this.treeMap.AtBottom())
                {
                    this.treeMap.Move();

                    if (this.treeMap.CurrSymbol() == "#")
                    {
                        treeCount += 1;
                    }
                }

                this.treeMap.Reset();

                return treeCount;
            }
        }
    }
}
