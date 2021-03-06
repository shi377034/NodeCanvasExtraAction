using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector3")]
    public class SelectRandomVector3 : ActionTask
    {
        public BBParameter<Vector3[]> vectorArray;
        public BBParameter<float[]> weights;
        [BlackboardOnly]
        public BBParameter<Vector3> storeVector;
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