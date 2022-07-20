// File: "OOP1Creat8"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractGraphic
        {
            public abstract AbstractGraphic Clone();
            public abstract void ChangeLocation(int x1, int y1,
                int x2, int y2);
            public abstract string Draw();
        }

        public class Ellip: AbstractGraphic{
            int x1, x2, y1, y2 = 0;
            public override AbstractGraphic Clone()
            {
                var temp = new Ellip();
                temp.ChangeLocation(x1, y1, x2, y2);
                return temp;
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
            public override string Draw()
            {
                return "Ellip(" + x1 + "," + y1 + "," + x2 + "," + y2 + ")";
            }
        }

        public class Line: AbstractGraphic{
            int x1, x2, y1, y2 = 0;
            public override AbstractGraphic Clone()
            {
                var temp = new Line();
                temp.ChangeLocation(x1, y1, x2, y2);
                return temp;
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
            public override string Draw()
            {
                return "Line(" + x1 + "," + y1 + "," + x2 + "," + y2 + ")";
            }
        }

        public class Rect: AbstractGraphic{
            int x1, x2, y1, y2 = 0;
            public override AbstractGraphic Clone()
            {
                var temp = new Rect();
                temp.ChangeLocation(x1, y1, x2, y2);
                return temp;
            }
            public override void ChangeLocation(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
            public override string Draw()
            {
                return "Rect(" + x1 + "," + y1 + "," + x2 + "," + y2 + ")";
            }
        }

        // Implement the Ellip, Line and Rect descendant classes

        public class GraphEditor
        {
            // Add required fields
            AbstractGraphic[] gE = new AbstractGraphic[2];
            List<AbstractGraphic> list = new List<AbstractGraphic>();
            public GraphEditor(AbstractGraphic p0, AbstractGraphic p1)
            {
                gE[0] = p0;
                gE[1] = p1;
                // Implement the constructor
            }
            public void AddGraphic(int ind, int x1, int y1, int x2, int y2)
            {
                // Implement the method
                var temp = gE[ind];
                temp.ChangeLocation(x1, y1, x2, y2);
                list.Add(temp.Clone());
            }
            public string DrawAll()
            {
                string res = list[0].Draw();

                for (int i = 1; i < list.Count; ++i) {
                    res += " " + list[i].Draw();
                } 
                return res;
                // Remove the previous statement and implement the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat8");

            AbstractGraphic typeSelector(char c) {
                if(c == 'E')
                 return new Ellip();
                else if(c == 'L')
                    return new Line();
                else
                    return new Rect();
            }

            string p = GetString();
            AbstractGraphic p0 = typeSelector(p[0]);
            AbstractGraphic p1 = typeSelector(p[1]);
            int n = GetInt();

            var graph = new GraphEditor(p0, p1);

            for (int i = 0; i < n; ++i) {
                int ind = GetInt();
                int x1 = GetInt();
                int y1 = GetInt();
                int x2 = GetInt();
                int y2 = GetInt();

                graph.AddGraphic(ind, x1, y1, x2 ,y2);
            }

            Put(graph.DrawAll());

        }
    }
}
