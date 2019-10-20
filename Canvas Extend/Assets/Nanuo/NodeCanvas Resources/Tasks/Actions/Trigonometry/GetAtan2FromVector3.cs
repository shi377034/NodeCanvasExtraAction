using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Trigonometry")]
    public class GetAtan2FromVector3 : ActionTask
    {
        public enum aTan2EnumAxis
        {
            x,
            y,
            z
        }
        public BBParameter<Vector3> vector3;
        [Tooltip("which axis in the vector3 to use as the x value of the tan")]
        public aTan2EnumAxis xAxis = aTan2EnumAxis.x;

        [Tooltip("which axis in the vector3 to use as the y value of the tan")]
        public aTan2EnumAxis yAxis = aTan2EnumAxis.y;
        public BBParameter<bool> RadToDeg = true;
        [BlackboardOnly]
        public BBParameter<float> angle;
        protected override void OnExecute()
        {
            float x = vector3.value.x;
            if (xAxis == aTan2EnumAxis.y)
            {
                x = vector3.value.y;
            }
            else if (xAxis == aTan2EnumAxis.z)
            {
                x = vector3.value.z;
            }
            float y = vector3.value.y;
            if (yAxis == aTan2EnumAxis.x)
            {
                y = vector3.value.x;
            }
            else if (yAxis == aTan2EnumAxis.z)
            {
                y = vector3.value.z;
            }
            float _angle = Mathf.Atan2(y, x);
            if (RadToDeg.value)
            {
                _angle = _angle * Mathf.Rad2Deg;
            }
            angle.value = _angle;
            EndAction();
        }
    }
}