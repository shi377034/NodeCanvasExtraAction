using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsGetFloat : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        [BlackboardOnly]
        public BBParameter<float> saveAs;
        protected override void OnExecute()
        {
            saveAs.value = PlayerPrefs.GetFloat(key.value, saveAs.value);
            EndAction();
        }
    }
}