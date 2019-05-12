using System;
using System.Linq;
using System.Collections.Generic;

namespace flowchart
{
    class Program
    {
        static void Main()
        {
            var shapes = createShapes();

            var layouter = new Layouter();
            shapes.First().Accept(layouter);

            var map = Enumerable.Range(0, shapes.Max(x => x.Row) + 1).Select(x =>
                Enumerable.Range(0, shapes.Max(y => y.Column) + 1).Select(y => "        ").ToArray()).ToList();

            var extructor = new DisplayTextCreator();
            foreach (var shape in shapes)
            {
                Console.WriteLine($"({shape.Column},{shape.Row}):{shape.Name}");
                map[shape.Row][shape.Column] = shape.Accept(extructor);
            }

            foreach (var row in map)
            {
                Console.WriteLine(string.Join("", row));
            }

            Console.WriteLine("please enter key to exit ...");
            Console.Read();
        }

        static private IEnumerable<ShapeBase> createShapes()
        {
            var shape00 = new ProcessShape("00");
            var shape01 = new DecisionShape("01");
            var shape02 = new ProcessShape("02");
            var shape12 = new DecisionShape("12");
            var shape23 = new DecisionShape("23");
            var shape13 = new ProcessShape("13");
            var shape05 = new ProcessShape("05");
            var shape34 = new DecisionShape("34");
            connectMain(shape00, shape01);
            connectMain(shape01, shape02);
            connectMain(shape02, shape05);
            connectSub(shape01, shape12);
            connectMain(shape12, shape13);
            connectMain(shape13, shape05);
            connectSub(shape12, shape23);
            connectMain(shape23, shape05);
            connectSub(shape23, shape34);
            connectMain(shape34, shape05);

            return new List<ShapeBase>()
            {
                shape00, shape01, shape02, shape12, shape23, shape13, shape05, shape34
            };
        }

        private static void connectMain(ShapeBase x, ShapeBase y)
        {
            var line = new ConnectorLine();
            x.SetMainLine(line);
            y.AddPreviousLine(line);
        }

        private static void connectSub(DecisionShape x, ShapeBase y)
        {
            var line = new ConnectorLine();
            x.SetSubLine(line);
            y.AddPreviousLine(line);
        }
    }
}
