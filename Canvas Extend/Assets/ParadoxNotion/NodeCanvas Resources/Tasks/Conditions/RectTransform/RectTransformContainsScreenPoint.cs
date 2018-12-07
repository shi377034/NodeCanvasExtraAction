using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("RectTransform")]
	public class RectTransformContainsScreenPoint : ConditionTask<RectTransform> {

        public BBParameter<Vector2> screenPointVector2;
        public BBParameter<bool> normalizedScreenPoint;
        [RequiredField]
        public BBParameter<Camera> camera;
        public BBParameter<bool> value;
        protected override string info
        {
            get { return string.Format("RectTransform.ContainsScreenPoint({0}) == {1} ", screenPointVector2, value); }
        }

        protected override bool OnCheck(){

			return DoCheck() == value.value;
		}
        bool DoCheck()
        {
            Vector2 _screenPoint = screenPointVector2.value;

            if (normalizedScreenPoint.value)
            {
                _screenPoint.x *= Screen.width;
                _screenPoint.y *= Screen.height;
            }

            return RectTransformUtility.RectangleContainsScreenPoint(agent, _screenPoint, camera.value);
        }

    }
}