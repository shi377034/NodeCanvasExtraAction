using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetAnchorMax : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> anchorMax;

        protected override void OnExecute()
        {
            agent.anchorMax = anchorMax.value;
            EndAction();
        }      
    }
}