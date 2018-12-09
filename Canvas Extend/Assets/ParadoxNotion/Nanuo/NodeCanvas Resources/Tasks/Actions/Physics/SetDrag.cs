using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class SetDrag : ActionTask<Rigidbody>
    {
        [SliderField(0, 10f)]
        public BBParameter<float> drag;
        protected override void OnExecute()
        {
            agent.drag = drag.value;
            EndAction();
        }
    }
}