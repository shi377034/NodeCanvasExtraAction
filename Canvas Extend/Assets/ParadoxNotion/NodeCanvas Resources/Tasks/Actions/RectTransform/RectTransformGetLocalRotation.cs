using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetLocalRotation : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector3> rotation;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        [BlackboardOnly]
        public BBParameter<float> z;

        protected override void OnExecute()
        {
            rotation.value = agent.eulerAngles;

            x.value = agent.eulerAngles.x;
            y.value = agent.eulerAngles.y;
            z.value = agent.eulerAngles.z;

            EndAction();
        }      
    }
}