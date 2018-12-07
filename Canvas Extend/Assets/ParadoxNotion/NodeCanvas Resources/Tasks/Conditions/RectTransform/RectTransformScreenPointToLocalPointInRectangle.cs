using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("RectTransform")]
	public class RectTransformScreenPointToLocalPointInRectangle : ConditionTask<RectTransform> {

        public BBParameter<Vector2> screenPointVector2;
        public BBParameter<bool> normalizedScreenPoint;
        [RequiredField]
        public BBParameter<Camera> camera;
        public BBParameter<bool> value;
        [BlackboardOnly]
        public BBParameter<Vector3> localPosition;
        protected override string info
        {
            get { return string.Format("RectTransform.ScreenPointToLocalPointInRectangle({0}) == {1} ", screenPointVector2, value); }
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
            Vector2 _localPosition;

            bool _result = false;
            _result = RectTransformUtility.ScreenPointToLocalPointInRectangle(agent, _screenPoint, camera.value, out _localPosition);
            localPosition.value = new Vector3(_localPosition.x, _localPosition.y, 0f);

            return _result;
        }

    }
}