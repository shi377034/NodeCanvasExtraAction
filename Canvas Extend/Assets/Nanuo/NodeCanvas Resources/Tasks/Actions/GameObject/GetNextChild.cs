using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetNextChild : ActionTask<GameObject>{
        [Tooltip("If you want to reset the iteration, raise this flag to true when you enter the state, it will indicate you want to start from the beginning again")]
        public BBParameter<bool> resetFlag;
        [BlackboardOnly]
        public BBParameter<GameObject> storeNextChild;
        
        private GameObject go;
        private int nextChildIndex;

        protected override void OnExecute(){
            if (resetFlag.value)
            {
                nextChildIndex = 0;
                resetFlag.value = false;
            }
            DoGetNextChild(agent);
            EndAction();
		}
        void DoGetNextChild(GameObject parent)
        {
            if (parent == null)
            {
                return;
            }

            // reset?

            if (go != parent)
            {
                go = parent;
                nextChildIndex = 0;
            }

            // no more children?
            // check first to avoid errors.

            if (nextChildIndex >= go.transform.childCount)
            {
                nextChildIndex = 0;
                return;
            }

            // get next child

            storeNextChild.value = parent.transform.GetChild(nextChildIndex).gameObject;


            // no more children?
            // check a second time to avoid process lock and possible infinite loop if the action is called again.
            // Practically, this enabled calling again this state and it will start again iterating from the first child.

            if (nextChildIndex >= go.transform.childCount)
            {
                nextChildIndex = 0;
                return;
            }

            // iterate the next child
            nextChildIndex++;
        }
    }
}