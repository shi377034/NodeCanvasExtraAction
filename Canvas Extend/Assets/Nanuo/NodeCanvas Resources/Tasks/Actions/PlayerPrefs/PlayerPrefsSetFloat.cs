using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsSetFloat : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        public BBParameter<float> value;
        protected override void OnExecute()
        {
            PlayerPrefs.SetFloat(key.value, value.value);
            EndAction();
        }
    }
}