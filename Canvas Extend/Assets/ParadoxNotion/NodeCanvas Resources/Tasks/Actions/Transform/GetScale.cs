using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class GetScale : ActionTask<Transform>
    {
        public Space space = Space.World;
        [BlackboardOnly]
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> xScale;
        [BlackboardOnly]
        public BBParameter<float> yScale;
        [BlackboardOnly]
        public BBParameter<float> zScale;
        protected override void OnExecute()
        {
            var scale = space == Space.World ? agent.lossyScale : agent.localScale;
            vector.value = scale;
            xScale.value = scale.x;
            yScale.value = scale.y;
            zScale.value = scale.z;
            EndAction();
        }
    }
}