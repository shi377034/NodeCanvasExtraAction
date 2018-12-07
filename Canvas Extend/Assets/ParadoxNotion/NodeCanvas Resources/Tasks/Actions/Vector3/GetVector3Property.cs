using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector3")]
    public class GetVector3Property : ActionTask
    {
        public enum PropertyType
        {
            Zero,
            One,
            Forward,
            Back,
            Right,
            Down,
            Left,
            Up,
            PositiveInfinity,
            NegativeInfinity,
        }
        public PropertyType propertyType = PropertyType.Zero;  
        [BlackboardOnly]
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeZ;
        protected override void OnExecute()
        {
            switch(propertyType)
            {
                case PropertyType.Zero:
                    SetValue(Vector3.zero);
                    break;
                case PropertyType.One:
                    SetValue(Vector3.one);
                    break;
                case PropertyType.Forward:
                    SetValue(Vector3.forward);
                    break;
                case PropertyType.Back:
                    SetValue(Vector3.back);
                    break;
                case PropertyType.Right:
                    SetValue(Vector3.right);
                    break;
                case PropertyType.Down:
                    SetValue(Vector3.down);
                    break;
                case PropertyType.Left:
                    SetValue(Vector3.left);
                    break;
                case PropertyType.Up:
                    SetValue(Vector3.up);
                    break;
                case PropertyType.PositiveInfinity:
                    SetValue(Vector3.positiveInfinity);
                    break;
                case PropertyType.NegativeInfinity:
                    SetValue(Vector3.negativeInfinity);
                    break;
            }
            EndAction();
        }
        void SetValue(Vector3 value)
        {
            vector.value = value;
            storeX.value = value.x;
            storeY.value = value.y;
            storeZ.value = value.z;
        }
    }
}