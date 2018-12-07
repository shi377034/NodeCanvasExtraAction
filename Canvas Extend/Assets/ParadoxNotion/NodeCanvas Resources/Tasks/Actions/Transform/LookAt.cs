using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("LookAt")]
    [Category("Transform")]
    public class LookAtSuper : ActionTask<Transform>
    {
        public BBParameter<GameObject> targetObject;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<Vector3> upVector;
        public BBParameter<bool> keepVertical = true;
        public BBParameter<bool> debug;
        public BBParameter<Color> debugLineColor = Color.yellow;
        private GameObject go;
        private GameObject goTarget;
        private Vector3 lookAtPos;
        private Vector3 lookAtPosWithVertical;
        protected override void OnExecute()
        {
            DoLookAt();
            EndAction();
        }
        void DoLookAt()
        {
            if (!UpdateLookAtPosition())
            {
                return;
            }

            go.transform.LookAt(lookAtPos,upVector.value);

            if (debug.value)
            {
                Debug.DrawLine(go.transform.position, lookAtPos, debugLineColor.value);
            }
        }
        public bool UpdateLookAtPosition()
        {
            goTarget = targetObject.value;

            if (goTarget != null)
            {
                lookAtPos = goTarget.transform.TransformPoint(targetPosition.value);
            }
            else
            {
                lookAtPos = targetPosition.value;
            }

            lookAtPosWithVertical = lookAtPos;

            if (keepVertical.value)
            {
                lookAtPos.y = go.transform.position.y;
            }

            return true;
        }
        public Vector3 GetLookAtPosition()
        {
            return lookAtPos;
        }

        public Vector3 GetLookAtPositionWithVertical()
        {
            return lookAtPosWithVertical;
        }
    }
}