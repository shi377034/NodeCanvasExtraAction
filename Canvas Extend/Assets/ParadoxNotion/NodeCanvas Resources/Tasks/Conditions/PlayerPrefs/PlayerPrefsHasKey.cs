using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("PlayerPrefs")]
	public class PlayerPrefsHasKey : ConditionTask {

		[RequiredField]
		public BBParameter<string> key;
		public BBParameter<bool> value;

		protected override string info{
			get{return "PlayerPrefs.HasKey " + key.ToString() + " == " + value;}
		}

		protected override bool OnCheck(){

			return PlayerPrefs.HasKey(key.value) == value.value;
		}
	}
}