using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class LookAt2d : ActionTask<GameObject>
    {
        public BBParameter<Vector2> vector2Target;
        public BBParameter<float> rotationOffset;
        public BBParameter<bool> debug;
        public BBParameter<Color> debugLineColor = Color.green;
        protected override void OnExecute(){
            DoLookAt();
            EndAction();
		}
        void DoLookAt()
        {
            var target = new Vector3(vector2Target.value.x, vector2Target.value.y, 0f);

            var diff = target - agent.transform.position;
            diff.Normalize();

            var rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            agent.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset.value);

            if (debug.value)
            {
                Debug.DrawLine(agent.transform.position, target, debugLineColor.value);
            }
        }
    }
}