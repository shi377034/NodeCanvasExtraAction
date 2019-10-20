using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("RectTransform")]
	public class RectTransformScreenPointToWorldPointInRectangle : ConditionTask<RectTransform> {

        public BBParameter<Vector2> screenPointVector2;
        public BBParameter<bool> normalizedScreenPoint;
        [RequiredField]
        public BBParameter<Camera> camera;
        public BBParameter<bool> value;
        [BlackboardOnly]
        public BBParameter<Vector3> worldPosition;
        protected override string info
        {
            get { return string.Format("RectTransform.ScreenPointToWorldPointInRectangle({0}) == {1} ", screenPointVector2, value); }
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
            Vector3 _worldPosition;

            bool _result = false;
            _result = RectTransformUtility.ScreenPointToWorldPointInRectangle(agent, _screenPoint, camera.value, out _worldPosition);
            worldPosition.value = _worldPosition;

            return _result;
        }

    }
}