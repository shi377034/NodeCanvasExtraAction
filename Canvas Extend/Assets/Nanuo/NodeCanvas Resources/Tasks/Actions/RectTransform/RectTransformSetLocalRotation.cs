using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetLocalRotation : ActionTask<RectTransform>
    {
        public BBParameter<Vector3> rotation;
        protected override void OnExecute()
        {
            agent.localEulerAngles = rotation.value;
            EndAction();
        }      
    }
}