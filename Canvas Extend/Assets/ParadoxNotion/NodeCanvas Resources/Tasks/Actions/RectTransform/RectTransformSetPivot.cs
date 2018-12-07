using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetPivot : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> pivot;
        protected override void OnExecute()
        {
            agent.pivot = pivot.value;
            EndAction();
        }      
    }
}