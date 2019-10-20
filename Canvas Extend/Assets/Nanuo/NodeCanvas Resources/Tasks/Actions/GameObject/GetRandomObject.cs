using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetRandomObject : ActionTask{

		[RequiredField] [TagField]
		public string searchTag = "Untagged";
		
		[BlackboardOnly]
		public BBParameter<GameObject> storeResult;

		protected override string info{
			get{return "GetRandomObject '" + searchTag + "' as " + storeResult; }
		}

		protected override void OnExecute(){
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
            if (gameObjects.Length > 0)
            {
                storeResult.value = gameObjects[Random.Range(0, gameObjects.Length)];
                return;
            }
			EndAction(true);
		}
	}
}