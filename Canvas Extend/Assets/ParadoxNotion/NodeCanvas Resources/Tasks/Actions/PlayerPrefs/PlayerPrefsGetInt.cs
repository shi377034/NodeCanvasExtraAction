using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsGetInt : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        [BlackboardOnly]
        public BBParameter<int> saveAs;
        protected override void OnExecute()
        {
            saveAs.value = PlayerPrefs.GetInt(key.value, saveAs.value);
            EndAction();
        }
    }
}