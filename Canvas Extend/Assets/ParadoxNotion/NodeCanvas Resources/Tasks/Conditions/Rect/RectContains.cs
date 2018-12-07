using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Rect")]
	public class RectContains : ConditionTask {

        public BBParameter<Rect> rectangle;
        public BBParameter<Vector3> point;
        public BBParameter<bool> value;
        protected override string info
        {
            get { return string.Format("{0}.Contains({1}) == {2} ", rectangle, point, value); }
        }

        protected override bool OnCheck(){

			return rectangle.value.Contains(point.value) == value.value;
		}
	}
}