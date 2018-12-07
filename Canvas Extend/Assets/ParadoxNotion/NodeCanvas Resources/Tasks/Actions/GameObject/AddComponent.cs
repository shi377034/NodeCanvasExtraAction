using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class AddComponent<T> : ActionTask<Transform> where T:Component{

		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info{
			get{return string.Format("Add {0} as {1}", typeof(T).Name, saveAs.ToString());}
		}

		protected override void OnExecute(){
			T o = agent.gameObject.AddComponent<T>();
			saveAs.value = o;
			EndAction( o != null );
		}
	}
}