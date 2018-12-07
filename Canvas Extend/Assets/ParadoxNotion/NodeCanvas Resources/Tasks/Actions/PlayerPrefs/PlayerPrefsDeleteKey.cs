using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("PlayerPrefs")]
    public class PlayerPrefsDeleteKey : ActionTask
    {
        [RequiredField]
        public BBParameter<string> key;
        protected override void OnExecute()
        {
            PlayerPrefs.DeleteKey(key.value);
            EndAction();
        }
    }
}