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

            double treeCount = 0;

            while (!treeMap.AtBottom())
            {
                treeMap.Move();

                if (treeMap.CurrSymbol() == "#")
                {
                    treeCount += 1;
                }
            }

            return Convert.ToString(treeCount);
        }

        public override string PartTwo(string input)
        {
            Coords startingLoc = new Coords(0,0);

            Map treeMap1 = new Map(CreateMap(input), startingLoc, 1, 1);

            double treeCount1 = 0;

            while (!treeMap1.AtBottom())
            {
                treeMap1.Move();

                if (treeMap1.CurrSymbol() == "#")
                {
                    treeCount1 += 1;
                }
            }

            Map treeMap2 = new Map(CreateMap(input), startingLoc, 3, 1);
            treeMap2.Reset();

            double treeCount2 = 0;

            while (!treeMap2.AtBottom())
            {
                treeMap2.Move();

                if (treeMap2.CurrSymbol() == "#")
                {
                    treeCount2 += 1;
                }
            }

            Map treeMap3 = new Map(CreateMap(input), startingLoc, 5, 1);
            treeMap3.Reset();

            double treeCount3 = 0;

            while (!treeMap3.AtBottom())
            {
                treeMap3.Move();

                if (treeMap3.CurrSymbol() == "#")
                {
                    treeCount3 += 1;
                }
            }

            Map treeMap4 = new Map(CreateMap(input), startingLoc, 7, 1);
            treeMap4.Reset();

            double treeCount4 = 0;

            while (!treeMap4.AtBottom())
            {
                treeMap4.Move();

                if (treeMap4.CurrSymbol() == "#")
                {
                    treeCount4 += 1;
                }
            }

            Map treeMap5 = new Map(CreateMap(input), startingLoc, 1, 2);
            treeMap5.Reset();

            double treeCount5 = 0;

            while (!treeMap5.AtBottom())
            {
                treeMap5.Move();

                if (treeMap5.CurrSymbol() == "#")
                {
                    treeCount5 += 1;
                }
            }

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

            int moveX;

            int moveY;

            List<string> graph;

            public Map(List<string> graph, Coords startingLoc, int travelX, int travelY)
            {
                this.graph = graph;

                this.loc = startingLoc;

                this.moveX = travelX;

                this.moveY = travelY;
            }

            public void Reset()
            {
                this.loc.x = 0;

                this.loc.y = 0;
            }

            public void Move()
            {
                var xLoc = (this.loc.x + (1 * this.moveX)) % (this.MapXDistance() + 1);

                this.loc.x = xLoc;

                var yLoc = (this.loc.y + (1 * this.moveY));

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
    }
}
