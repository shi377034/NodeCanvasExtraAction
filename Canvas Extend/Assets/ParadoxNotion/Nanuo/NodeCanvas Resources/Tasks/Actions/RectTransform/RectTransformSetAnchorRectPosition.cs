using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformSetAnchorRectPosition : ActionTask<RectTransform>
    {
        public enum AnchorReference { TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left, Center };
        public AnchorReference anchorReference = AnchorReference.BottomLeft;
        public BBParameter<bool> normalized;
        public BBParameter<Vector2> anchor;
        Rect _anchorRect;
        protected override void OnExecute()
        {
            _anchorRect = new Rect();
            _anchorRect.min = agent.anchorMin;
            _anchorRect.max = agent.anchorMax;
            Vector2 _anchor = Vector2.zero;
            _anchor = _anchorRect.min;
            if (normalized.value)
            {
                _anchor = anchor.value;
            }
            else
            {
                _anchor.x = anchor.value.x / Screen.width;
                _anchor.y = anchor.value.y / Screen.height;
            }
            if (anchorReference == AnchorReference.BottomLeft)
            {
                _anchorRect.x = _anchor.x;
                _anchorRect.y = _anchor.y;

            }
            else if (anchorReference == AnchorReference.Left)
            {
                _anchorRect.x = _anchor.x;
                _anchorRect.y = _anchor.y - 0.5f;
            }
            else if (anchorReference == AnchorReference.TopLeft)
            {
                _anchorRect.x = _anchor.x;
                _anchorRect.y = _anchor.y - 1f;
            }
            else if (anchorReference == AnchorReference.Top)
            {
                _anchorRect.x = _anchor.x - 0.5f;
                _anchorRect.y = _anchor.y - 1f;
            }
            else if (anchorReference == AnchorReference.TopRight)
            {
                _anchorRect.x = _anchor.x - 1f;
                _anchorRect.y = _anchor.y - 1f;
            }
            else if (anchorReference == AnchorReference.Right)
            {
                _anchorRect.x = _anchor.x - 1f;
                _anchorRect.y = _anchor.y - 0.5f;
            }
            else if (anchorReference == AnchorReference.BottomRight)
            {
                _anchorRect.x = _anchor.x - 1f;
                _anchorRect.y = _anchor.y;
            }
            else if (anchorReference == AnchorReference.Bottom)
            {
                _anchorRect.x = _anchor.x - 0.5f;
                _anchorRect.y = _anchor.y;
            }
            else if (anchorReference == AnchorReference.Center)
            {
                _anchorRect.x = _anchor.x - 0.5f;
                _anchorRect.y = _anchor.y - 0.5f;
            }
            // apply
            agent.anchorMin = _anchorRect.min;
            agent.anchorMax = _anchorRect.max;

            EndAction();
        }      
    }
}