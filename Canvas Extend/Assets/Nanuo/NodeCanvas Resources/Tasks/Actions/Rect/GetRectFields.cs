using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Rect")]
    public class GetRectFields : ActionTask
    {
        public BBParameter<Rect> rect;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeWidth;
        [BlackboardOnly]
        public BBParameter<float> storeHeight;
        protected override void OnExecute()
        {
            storeX.value = rect.value.x;
            storeY.value = rect.value.y;
            storeWidth.value = rect.value.width;
            storeHeight.value = rect.value.height;
            EndAction();
        }
    }
}