using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetCollider2dIsTrigger : ActionTask<Collider2D>
    {
        public BBParameter<bool> isTrigger;
        [Tooltip("Set all Colliders on the GameObject target")]
        public BBParameter<bool> setAllColliders;
        protected override void OnExecute(){
            if (setAllColliders.value)
            {
                // Find all of the colliders on the gameobject and set them all to be triggers.
                Collider2D[] cols = agent.GetComponents<Collider2D>();
                foreach (Collider2D c in cols)
                {
                    c.isTrigger = isTrigger.value;
                }
            }
            else
            {
                Collider2D collider2D = agent.GetComponent<Collider2D>();
                if (collider2D != null) collider2D.isTrigger = isTrigger.value;
            }
            EndAction();
		}
	}
}