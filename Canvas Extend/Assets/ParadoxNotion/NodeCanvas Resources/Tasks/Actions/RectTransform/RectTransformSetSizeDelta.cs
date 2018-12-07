using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetSizeDelta : ActionTask<RectTransform>
    {
        public BBParameter<Vector2> sizeDelta;
        protected override void OnExecute()
        {
            agent.sizeDelta = sizeDelta.value;
            EndAction();
        }      
    }
}