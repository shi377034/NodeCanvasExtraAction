using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetAnchorMinAndMax : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> anchorMax;
        public BBParameter<Vector2> anchorMin;
       
        protected override void OnExecute()
        {
            agent.anchorMax = anchorMax.value;
            agent.anchorMin = anchorMin.value;
            EndAction();
        }      
    }
}