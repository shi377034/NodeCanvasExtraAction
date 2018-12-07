using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class GetVector2Property : ActionTask
    {
        public enum PropertyType
        {
            Zero,
            One,
            Right,
            Down,
            Left,
            Up,
            PositiveInfinity,
            NegativeInfinity,
        }
        public PropertyType propertyType = PropertyType.Zero;  
        [BlackboardOnly]
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        protected override void OnExecute()
        {
            switch(propertyType)
            {
                case PropertyType.Zero:
                    SetValue(Vector2.zero);
                    break;
                case PropertyType.One:
                    SetValue(Vector2.one);
                    break;
                case PropertyType.Right:
                    SetValue(Vector2.right);
                    break;
                case PropertyType.Down:
                    SetValue(Vector2.down);
                    break;
                case PropertyType.Left:
                    SetValue(Vector2.left);
                    break;
                case PropertyType.Up:
                    SetValue(Vector2.up);
                    break;
                case PropertyType.PositiveInfinity:
                    SetValue(Vector2.positiveInfinity);
                    break;
                case PropertyType.NegativeInfinity:
                    SetValue(Vector2.negativeInfinity);
                    break;
            }
            EndAction();
        }
        void SetValue(Vector2 value)
        {
            vector.value = value;
            storeX.value = value.x;
            storeY.value = value.y;
        }
    }
}