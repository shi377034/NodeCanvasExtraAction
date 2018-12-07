using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class RotateAround : ActionTask<Transform>
    {
        public BBParameter<Vector3> point;
        public BBParameter<float> angle;
        public BBParameter<Vector3> axis;
        public BBParameter<bool> perSecond;

        protected override void OnExecute()
        {
            agent.RotateAround(point.value, axis.value, perSecond.value ? angle.value * Time.deltaTime : angle.value);
            EndAction();
        }
    }
}