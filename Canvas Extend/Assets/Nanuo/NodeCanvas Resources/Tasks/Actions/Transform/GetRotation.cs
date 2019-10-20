using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class GetRotation : ActionTask<Transform>
    {
        public Space space = Space.World;
        [BlackboardOnly]
        public BBParameter<Quaternion> quaternion;
        [BlackboardOnly]
        [Name("Euler Angles")]
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> xAngle;
        [BlackboardOnly]
        public BBParameter<float> yAngle;
        [BlackboardOnly]
        public BBParameter<float> zAngle;
        protected override void OnExecute()
        {
            if (space == Space.World)
            {
                quaternion.value = agent.rotation;

                var rotation = agent.eulerAngles;

                vector.value = rotation;
                xAngle.value = rotation.x;
                yAngle.value = rotation.y;
                zAngle.value = rotation.z;
            }
            else
            {
                var rotation = agent.localEulerAngles;

                quaternion.value = Quaternion.Euler(rotation);

                vector.value = rotation;
                xAngle.value = rotation.x;
                yAngle.value = rotation.y;
                zAngle.value = rotation.z;
            }
            EndAction();
        }
    }
}