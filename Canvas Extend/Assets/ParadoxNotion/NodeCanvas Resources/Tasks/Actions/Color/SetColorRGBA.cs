using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class SetColorRGBA : ActionTask
    {
        [SliderField(0,1f)]
        public BBParameter<float> red;
        [SliderField(0,1f)]
        public BBParameter<float> green;
        [SliderField(0,1f)]
        public BBParameter<float> blue;
        [SliderField(0,1f)]
        public BBParameter<float> alpha;
        [BlackboardOnly]
        public BBParameter<Color> setTo;
        protected override void OnExecute(){
            var newColor = setTo.value;
            newColor.r = red.value;
            newColor.g = green.value;
            newColor.b = blue.value;
            newColor.a = alpha.value;
            setTo.value = newColor;
            EndAction();
        }
    }
}