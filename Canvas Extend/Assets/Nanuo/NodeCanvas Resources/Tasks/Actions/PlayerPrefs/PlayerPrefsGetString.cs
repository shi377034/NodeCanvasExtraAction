using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsGetString : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        [BlackboardOnly]
        public BBParameter<string> saveAs;
        protected override void OnExecute()
        {
            saveAs.value = PlayerPrefs.GetString(key.value, saveAs.value);
            EndAction();
        }
    }
}