using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Trigonometry")]
    public class GetCosine : ActionTask
    {
        public BBParameter<float> angle;
        public BBParameter<bool> DegToRad = true;
        public BBParameter<float> result;
        protected override void OnExecute()
        {
            float _angle = angle.value;
            if (DegToRad.value)
            {
                _angle = _angle * Mathf.Deg2Rad;
            }
            result.value = Mathf.Cos(_angle);
            EndAction();
        }
    }
}