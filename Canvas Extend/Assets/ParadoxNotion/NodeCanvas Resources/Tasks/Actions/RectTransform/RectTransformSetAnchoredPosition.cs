using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetAnchoredPosition : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> position;

        protected override void OnExecute()
        {
            agent.anchoredPosition = position.value;
            EndAction();
        }      
    }
}