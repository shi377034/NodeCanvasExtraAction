using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Is ChildOf")]
	[Category("GameObject")]
	public class GameObjectIsChildOf : ConditionTask<GameObject> {
        [RequiredField]
        [Tooltip("Is it a child of this GameObject?")]
        public BBParameter<GameObject> isChildOf;

        protected override string info{
			get{return "GameObject.IsChildOf " + isChildOf; }
		}

		protected override bool OnCheck(){
			return agent.transform.IsChildOf(isChildOf.value.transform);
		}
	}
}