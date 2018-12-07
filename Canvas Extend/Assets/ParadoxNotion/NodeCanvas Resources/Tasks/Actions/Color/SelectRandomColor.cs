using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class SelectRandomColor : ActionTask
    {
        public BBParameter<List<Color>> colors;
        [SliderField(0,1f)]
        public BBParameter<List<float>> weights;
        [BlackboardOnly]
        public BBParameter<Color> storeColor;
        protected override void OnExecute(){
            int randomIndex = weights.value.RandomWeightedIndex();
            if (randomIndex != -1)
            {
                storeColor.value = colors.value[randomIndex];
            }
            EndAction();
        }
    }
}