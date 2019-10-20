using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SetRotation : ActionTask<Transform>
    {
        public enum SetMode
        {
            Quaternion,
            Vector3
        }
        public SetMode mode = SetMode.Vector3;
        [ShowIf("mode", (int)SetMode.Quaternion)]
        public BBParameter<Quaternion> quaternion;
        [ShowIf("mode", (int)SetMode.Vector3)]
        public BBParameter<Vector3> vector;
        public Space space = Space.World;
        protected override void OnExecute()
        {
            Vector3 rotation = space == Space.Self ? agent.localEulerAngles : agent.eulerAngles;
            switch (mode)
            {
                case SetMode.Quaternion:
                    rotation = quaternion.value.eulerAngles;
                    break;
                case SetMode.Vector3:
                    rotation = vector.value;
                    break;
            }
            if (space == Space.Self)
            {
                agent.localEulerAngles = rotation;
            }
            else
            {
                agent.eulerAngles = rotation;
            }
            EndAction();
        }
    }
}