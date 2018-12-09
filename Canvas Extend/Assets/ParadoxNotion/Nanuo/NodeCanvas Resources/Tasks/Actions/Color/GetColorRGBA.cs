using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class GetColorRGBA : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<Color> color;
        [BlackboardOnly]
        public BBParameter<float> storeRed;
        [BlackboardOnly]
        public BBParameter<float> storeGreen;
        [BlackboardOnly]
        public BBParameter<float> storeBlue;
        [BlackboardOnly]
        public BBParameter<float> storeAlpha;
        protected override void OnExecute(){
            storeRed.value = color.value.r;
            storeGreen.value = color.value.g;
            storeBlue.value = color.value.b;
            storeAlpha.value = color.value.a;
            EndAction();
        }
    }
}