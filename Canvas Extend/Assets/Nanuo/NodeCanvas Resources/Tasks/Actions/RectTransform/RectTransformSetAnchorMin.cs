using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetAnchorMin : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> anchorMin;

        protected override void OnExecute()
        {
            agent.anchorMin = anchorMin.value;
            EndAction();
        }      
    }
}