using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformWorldToScreenPoint : ActionTask<RectTransform>
    {
        [RequiredField]
        public BBParameter<Camera> camera;
        public BBParameter<bool> normalize;
        [BlackboardOnly]
        public BBParameter<Vector3> screenPoint;
        [BlackboardOnly]
        public BBParameter<float> screenX;
        [BlackboardOnly]
        public BBParameter<float> screenY;
        
        protected override void OnExecute()
        {
            var position = RectTransformUtility.WorldToScreenPoint(camera.value, agent.position);

            if (normalize.value)
            {
                position.x /= Screen.width;
                position.y /= Screen.height;
            }

            screenPoint.value = position;
            screenX.value = position.x;
            screenY.value = position.y;
            EndAction();
        }      
    }
}