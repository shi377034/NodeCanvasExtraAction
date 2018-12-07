using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetOffsetMin : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> offsetMin;
        protected override void OnExecute()
        {
            agent.offsetMin = offsetMin.value;
            EndAction();
        }      
    }
}