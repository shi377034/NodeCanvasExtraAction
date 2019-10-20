using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SetTagsOnChildren : ActionTask<Transform>{
        [TagField]
        public string tag;
        protected override void OnExecute(){
            foreach(Transform child in agent)
            {
                child.gameObject.tag = tag;
            }
            EndAction();
		}
	}
}