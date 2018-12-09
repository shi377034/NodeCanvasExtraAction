using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class GetAngleToVector3 : ActionTask<Transform>
    {
        public enum Direction
        {
            Forward,
            Right,
            Up,
        }
        public Direction direction = Direction.Forward;
        public BBParameter<Vector3> vector;
        public BBParameter<bool> ignoreHeight;
        [BlackboardOnly]
        public BBParameter<float> angle;
        [BlackboardOnly]
        public BBParameter<float> signedAngle;
        public bool repeat;
        protected override void OnExecute() { Do(); }
        protected override void OnUpdate() { Do(); }

        void Do()
        {
            Vector3 from = agent.forward;
            switch(direction)
            {
                case Direction.Forward:
                    from = agent.forward;
                    break;
                case Direction.Right:
                    from = agent.right;
                    break;
                case Direction.Up:
                    from = agent.up;
                    break;
            }
            Vector3 to = vector.value;
            if (ignoreHeight.value)
            {
                from.y = 0;
                to.y = 0;
            }
            angle.value = Vector3.Angle(from, to);
            signedAngle.value = Vector3.SignedAngle(from, to, agent.up);
            if (!repeat)
                EndAction();
        }
    }
}