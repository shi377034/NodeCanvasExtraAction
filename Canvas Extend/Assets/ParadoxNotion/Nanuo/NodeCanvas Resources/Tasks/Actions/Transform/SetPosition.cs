using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SetPosition : ActionTask<Transform>
    {
        public Space space = Space.World;
        public BBParameter<GameObject> target;
        public BBParameter<Vector3> vector;
        protected override void OnExecute()
        {
            Vector3 position;

            if (target.value != null)
            {
                position = space == Space.World ? target.value.transform.position : target.value.transform.localPosition;
            }
            else
            {
                position = vector.value;
            }

            // apply

            if (space == Space.World)
            {
                agent.position = position;
            }
            else
            {
                agent.localPosition = position;
            }
            EndAction();
        }
    }
}