using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Rect")]
    public class SetRectFields : ActionTask
    {
        public BBParameter<float> x;
        public BBParameter<float> y;
        public BBParameter<float> width;
        public BBParameter<float> height;
        [BlackboardOnly]
        public BBParameter<Rect> rect;
        protected override void OnExecute()
        {
            var newRect = rect.value;
            newRect.x = x.value;
            newRect.y = y.value;
            newRect.width = width.value;
            newRect.height = height.value;
            rect.value = newRect;

            EndAction();
        }
    }
}