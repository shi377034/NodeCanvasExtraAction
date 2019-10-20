using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Category("Application")]
    public class GetScreenResolution : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<float> saveWidth;
        [BlackboardOnly]
        public BBParameter<float> saveHeight;
        [BlackboardOnly]
        public BBParameter<Vector2> saveAs;
        protected override void OnExecute()
        {
            saveWidth.value = Screen.width;
            saveHeight.value = Screen.height;
            saveAs.value = new Vector2(Screen.width, Screen.height);
            EndAction();
        }
    }
}