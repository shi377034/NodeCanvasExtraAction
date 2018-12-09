using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsSetInt : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        public BBParameter<int> value;
        protected override void OnExecute()
        {
            PlayerPrefs.SetInt(key.value, value.value);
            EndAction();
        }
    }
}