using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Input")]
	public class AnyKeyDown : ConditionTask{

		protected override bool OnCheck(){
			return Input.anyKeyDown;					
		}
	}
}