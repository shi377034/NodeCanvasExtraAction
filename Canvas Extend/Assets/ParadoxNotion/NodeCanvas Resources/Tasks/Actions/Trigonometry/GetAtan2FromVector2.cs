using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Trigonometry")]
    public class GetAtan2FromVector2 : ActionTask
    {
        public BBParameter<Vector2> vector2;
        public BBParameter<bool> RadToDeg = true;
        [BlackboardOnly]
        public BBParameter<float> angle;
        protected override void OnExecute()
        {
            float _angle = Mathf.Atan2(vector2.value.y, vector2.value.x);
            if (RadToDeg.value)
            {
                _angle = _angle * Mathf.Rad2Deg;
            }
            angle.value = _angle;
            EndAction();
        }
    }
}