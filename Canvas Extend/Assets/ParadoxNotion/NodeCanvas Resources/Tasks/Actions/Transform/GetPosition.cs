using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class GetPosition : ActionTask<Transform>
    {
        public Space space = Space.World;
        [BlackboardOnly]
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        [BlackboardOnly]
        public BBParameter<float> z;
        protected override void OnExecute()
        {
            var position = space == Space.World ? agent.position : agent.localPosition;
            vector.value = position;
            x.value = position.x;
            y.value = position.y;
            z.value = position.z;
            EndAction();
        }
    }
}