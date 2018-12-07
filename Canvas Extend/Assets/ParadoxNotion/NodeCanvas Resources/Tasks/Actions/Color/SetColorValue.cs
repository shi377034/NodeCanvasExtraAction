using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class SetColorValue : ActionTask
    {
        public BBParameter<Color> color;
        [BlackboardOnly]
        public BBParameter<Color> setTo;
        protected override void OnExecute(){
            setTo.value = color.value;
            EndAction();
        }
    }
}