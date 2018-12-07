using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Trigonometry")]
    public class GetAtan2 : ActionTask
    {
        public BBParameter<float> xValue;
        public BBParameter<float> yValue;
        public BBParameter<bool> RadToDeg = true;
        [BlackboardOnly]
        public BBParameter<float> angle;
        protected override void OnExecute()
        {
            float _angle = Mathf.Atan2(yValue.value, xValue.value);
            if (RadToDeg.value)
            {
                _angle = _angle * Mathf.Rad2Deg;
            }
            angle.value = _angle;
            EndAction();
        }
    }
}