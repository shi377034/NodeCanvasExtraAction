using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformFlipLayoutAxis : ActionTask<RectTransform>
    {
        public enum RectTransformFlipOptions { Horizontal, Vertical, Both };
        public RectTransformFlipOptions axis = RectTransformFlipOptions.Both;
        public BBParameter<bool> keepPositioning;
        public BBParameter<bool> recursive;

        protected override void OnExecute()
        {
            DoFlip();
            EndAction();
        }
        void DoFlip()
        {
            if (axis == RectTransformFlipOptions.Both)
            {
                RectTransformUtility.FlipLayoutAxes(agent, keepPositioning.value, recursive.value);
            }
            else if (axis == RectTransformFlipOptions.Horizontal)
            {
                RectTransformUtility.FlipLayoutOnAxis(agent, 0, keepPositioning.value, recursive.value);
            }
            else if (axis == RectTransformFlipOptions.Vertical)
            {
                RectTransformUtility.FlipLayoutOnAxis(agent, 1, keepPositioning.value, recursive.value);
            }
        }
    }
}