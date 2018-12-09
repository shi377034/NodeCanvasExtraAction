using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SetRandomRotation : ActionTask<Transform>
    {
        public BBParameter<bool> x;
        public BBParameter<bool> y;
        public BBParameter<bool> z;
        protected override void OnExecute()
        {
            Vector3 rotation = agent.localEulerAngles;

            float xAngle = rotation.x;
            float yAngle = rotation.y;
            float zAngle = rotation.z;

            xAngle = Random.Range(0, 360);
            yAngle = Random.Range(0, 360);
            zAngle = Random.Range(0, 360);

            agent.localEulerAngles = new Vector3(xAngle, yAngle, zAngle);
            EndAction();
        }
    }
}