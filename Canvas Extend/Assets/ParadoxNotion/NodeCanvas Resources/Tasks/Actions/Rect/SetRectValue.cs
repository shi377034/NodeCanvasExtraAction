using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Rect")]
    public class SetRectValue : ActionTask
    {
        public BBParameter<Rect> rect;
        [BlackboardOnly]
        public BBParameter<Rect> storeRect;
        protected override void OnExecute()
        {
            storeRect.value = rect.value;
            EndAction();
        }
    }
}