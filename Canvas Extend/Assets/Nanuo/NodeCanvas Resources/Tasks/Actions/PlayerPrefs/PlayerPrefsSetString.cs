using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsSetString : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        public BBParameter<string> value;
        protected override void OnExecute()
        {
            PlayerPrefs.SetString(key.value, value.value);
            EndAction();
        }
    }
}