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
            public abstract void ChangeLocation(int x1, int y1, int x2, int y2);
            public abstract string Draw();
        }

        // РЕАЛИЗУЙТЕ КЛАССЫ-ПОТОМКИ Ellip, Line И Rect

        public class Ellip : AbstractGraphic {
	int x1=0,y1=0,x2=0,y2=0;
		public override AbstractGraphic Clone() {
			return (Ellip)MemberwiseClone();
		}
		public override void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		}
		public override string  Draw() {
			string ans = "Ellip(";
			ans+=x1.ToString(); ans+=","; ans+=y1.ToString(); ans+=",";
			ans+=x2.ToString(); ans+=","; ans+=y2.ToString();
			ans += ")";
			Show (ans);
		return ans;
		}
};

public class Line : AbstractGraphic {
	public int x1=0,y1=0,x2=0,y2=0;
	
		public override AbstractGraphic Clone() {
			return (Line)MemberwiseClone();
		}
		public override void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		}
		public override string Draw() {
			string ans = "Line(";
            ans+=x1.ToString(); ans+=","; ans+=y1.ToString(); ans+=",";
			ans+=x2.ToString(); ans+=","; ans+=y2.ToString();
			ans += ")";
			Show (ans);
		return ans;
		}
};

public class Rect : AbstractGraphic {
	public int x1=0,y1=0,x2=0,y2=0;
		public override AbstractGraphic Clone() {
			return (Rect)MemberwiseClone();
		}
		public override void ChangeLocation(int x1_, int y1_, int x2_, int y2_) {
			x1=x1_;y1=y1_;x2=x2_;y2=y2_;
		}
		public override string Draw() {
			string ans = "Rect(";
			ans+=x1.ToString(); ans+=","; ans+=y1.ToString(); ans+=",";
			ans+=x2.ToString(); ans+=","; ans+=y2.ToString();
			ans += ")";
			Show (ans);
		return ans;
		}
};

        public class GraphEditor
        {
            // ДОБАВЬТЕ НЕОБХОДИМЫЕ ПОЛЯ
            List <string> Drawings = new List<string>();
            List <AbstractGraphic> Params = new List <AbstractGraphic>();
            public GraphEditor(AbstractGraphic p1, AbstractGraphic p2)
            {
                // РЕАЛИЗУЙТЕ КОНСТРУКТОР
                Params.Add(p1.Clone());
                Params.Add(p2.Clone());
            }
            public void AddGraphic(int np, int x1, int y1, int x2, int y2)
            {
                Params[np-1].ChangeLocation(x1,y1,x2,y2);
                Drawings.Add(Params[np-1].Draw());
                // РЕАЛИЗУЙТЕ МЕТОД
            }
            public string DrawAll()
            {
                return string.Join(" ",Drawings);
                // УДАЛИТЕ ПРЕДЫДУЩИЙ ОПЕРАТОР И РЕАЛИЗУЙТЕ МЕТОД
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat8");
            string tmp = GetString(); int n = GetInt();

            AbstractGraphic pt1 = (new Rect()).Clone();
            if (tmp[0] == 'R') pt1 = (new Rect()).Clone();
	        else if (tmp[0] == 'E') pt1 = (new Ellip()).Clone();
	        else if (tmp[0] == 'L') pt1 = (new Line()).Clone();

            AbstractGraphic pt2= new Rect().Clone();
            if (tmp[1] == 'R') pt2 = (new Rect()).Clone();
	        else if (tmp[1] == 'E') pt2 = (new Ellip()).Clone();
	        else if (tmp[1] == 'L') pt2 = (new Line()).Clone();

            GraphEditor ge = new GraphEditor(pt1,pt2);
	
	        for (int i=0;i<n;i++) {
		    int np,x1,y1,x2,y2;
            np = GetInt();
            x1 = GetInt();
            y1 = GetInt();
            x2 = GetInt();
            y2 = GetInt();
		    ge.AddGraphic(np,x1,y1,x2,y2);
	}
	
	Put(ge.DrawAll());

        }
    }
}
