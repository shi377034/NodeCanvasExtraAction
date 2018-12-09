using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class SelectRandomVector2 : ActionTask
    {
        public BBParameter<Vector2[]> vectorArray;
        public BBParameter<float[]> weights;
        [BlackboardOnly]
        public BBParameter<Vector2> storeVector;
        protected override void OnExecute()
        {
            int randomIndex = weights.value.RandomWeightedIndex();

            if (randomIndex != -1 && vectorArray.value.Length > 0)
            {
                storeVector.value = vectorArray.value[randomIndex];
            }
            EndAction();
        }
    }
}