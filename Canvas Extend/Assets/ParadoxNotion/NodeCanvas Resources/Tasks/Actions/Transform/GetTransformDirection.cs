using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Transform")]
    public class GetTransformDirection : ActionTask<Transform>
    {
        public enum PropertyType
        {
            Forward,
            Right,
            Up,
        }
        public PropertyType propertyType = PropertyType.Forward;  
        [BlackboardOnly]
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeZ;
        protected override string info
        {
            get
            {
                return string.Format("Get transform.{0}", propertyType);
            }
        }
        protected override void OnExecute()
        {
            switch(propertyType)
            {
                case PropertyType.Forward:
                    SetValue(agent.forward);
                    break;
                case PropertyType.Right:
                    SetValue(agent.right);
                    break;

                case PropertyType.Up:
                    SetValue(agent.up);
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