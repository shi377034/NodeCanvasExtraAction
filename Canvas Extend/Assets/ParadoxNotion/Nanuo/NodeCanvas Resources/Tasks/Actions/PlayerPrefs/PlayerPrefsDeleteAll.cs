using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("PlayerPrefs")]
	public class PlayerPrefsDeleteAll : ActionTask
    {  
        protected override void OnExecute(){
            PlayerPrefs.DeleteAll();
            EndAction();
		}
	}
}