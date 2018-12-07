using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Rect")]
	public class RectOverlaps : ConditionTask {

        public BBParameter<Rect> rect1;
        public BBParameter<Rect> rect2;
        public BBParameter<bool> value;
        protected override string info{
			get{return string.Format("{0}.Overlaps({1}) == {2} ", rect1, rect2, value);}
		}

		protected override bool OnCheck(){

			return Intersect(rect1.value, rect2.value) == value.value;
		}
        public static bool Intersect(Rect a, Rect b)
        {
            FlipNegative(ref a);
            FlipNegative(ref b);
            bool c1 = a.xMin < b.xMax;
            bool c2 = a.xMax > b.xMin;
            bool c3 = a.yMin < b.yMax;
            bool c4 = a.yMax > b.yMin;
            return c1 && c2 && c3 && c4;
        }

        public static void FlipNegative(ref Rect r)
        {
            if (r.width < 0)
                r.x -= (r.width *= -1);
            if (r.height < 0)
                r.y -= (r.height *= -1);
        }
    }
}