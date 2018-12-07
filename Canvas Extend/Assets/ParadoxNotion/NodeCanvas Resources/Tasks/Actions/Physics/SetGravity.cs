using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class SetGravity : ActionTask
    {
        public BBParameter<Vector3> vector;
        protected override void OnExecute()
        {
            Physics.gravity = vector.value;
            EndAction();
        }
    }
}