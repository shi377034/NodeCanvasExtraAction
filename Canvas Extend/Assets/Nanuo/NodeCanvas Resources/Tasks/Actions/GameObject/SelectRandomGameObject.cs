using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SelectRandomGameObject : ActionTask<Transform>{
        public BBParameter<List<GameObject>> gameObjects;
        [SliderField(0,1f)]
        public BBParameter<List<float>> weights;
        [BlackboardOnly]
        public BBParameter<GameObject> storeResult;

        protected override void OnExecute(){
            int randomIndex = weights.value.RandomWeightedIndex();
            if (randomIndex != -1)
            {
                storeResult.value = gameObjects.value[randomIndex];
            }
            EndAction();
		}
	}
}