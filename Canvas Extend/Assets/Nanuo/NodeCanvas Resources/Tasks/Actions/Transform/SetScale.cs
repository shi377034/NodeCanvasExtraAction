using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SetScale : ActionTask<Transform>
    {
        public BBParameter<Vector3> vector;
        protected override void OnExecute()
        {
            var scale = vector.value;
            agent.localScale = scale;
            EndAction();
        }
    }
}