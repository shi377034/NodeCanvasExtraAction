using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetOffsetMax : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> offsetMax;
        protected override void OnExecute()
        {
            agent.offsetMax = offsetMax.value;
            EndAction();
        }      
    }
}