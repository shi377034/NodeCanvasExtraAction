using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class LookAt2dGameObject : ActionTask<GameObject>
    {
        public BBParameter<GameObject> targetObject;
        public BBParameter<float> rotationOffset;
        public BBParameter<bool> debug;
        public BBParameter<Color> debugLineColor = Color.green;

        private GameObject goTarget;
        protected override void OnExecute(){
            if (targetObject.value == null)
            {
                EndAction(false);
                return;
            }
            DoLookAt();
            EndAction();
		}
        void DoLookAt()
        {
            goTarget = targetObject.value;



            var diff = goTarget.transform.position - agent.transform.position;
            diff.Normalize();

            var rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            agent.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset.value);

            if (debug.value)
            {
                Debug.DrawLine(agent.transform.position, goTarget.transform.position, debugLineColor.value);
            }
        }
    }
}