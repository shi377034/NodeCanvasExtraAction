using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("GameObject")]
    public class GetTagCount : ActionTask
    {

        [RequiredField]
        [TagField]
        public string searchTag = "Untagged";

        [BlackboardOnly]
        public BBParameter<int> storeResult;

        protected override string info
        {
            get { return "GetRandomObject '" + searchTag + "' as " + storeResult; }
        }

        protected override void OnExecute()
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
            storeResult.value = gameObjects == null ? 0 : gameObjects.Length;
            EndAction(true);
        }
    }
}