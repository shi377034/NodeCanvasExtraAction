using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetLocalPosition : ActionTask<RectTransform>
    {
        public BBParameter<Vector3> position;


        protected override void OnExecute()
        {
            Vector3 _pos = agent.localPosition;
            _pos = position.value;
            agent.localPosition = _pos;
            EndAction();
        }      
    }
}