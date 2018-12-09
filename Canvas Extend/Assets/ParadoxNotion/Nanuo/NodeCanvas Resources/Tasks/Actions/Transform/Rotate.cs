using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class Rotate : ActionTask<Transform>
    {
        public BBParameter<Vector3> vector;
        public Space space = Space.Self;
        public BBParameter<bool> perSecond;

        protected override void OnExecute()
        {
            var rotate = vector.value;
            agent.Rotate(perSecond.value ? rotate * Time.deltaTime : rotate, space);
            EndAction();
        }
    }
}