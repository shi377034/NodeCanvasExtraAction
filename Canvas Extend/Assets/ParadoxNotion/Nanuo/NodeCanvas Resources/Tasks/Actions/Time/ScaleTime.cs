using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Time")]
    [Description("Gets various useful Time measurements.")]
    public class ScaleTime : ActionTask
    {
        [SliderField(0,4f)]
        [Tooltip("Scales time: 1 = normal, 0.5 = half speed, 2 = double speed.")]
        public BBParameter<float> timeScale = 1f;
        public BBParameter<bool> adjustFixedDeltaTime = true;
        [RequiredField]
        public BBParameter<float> storeValue;
        protected override string info
        {
            get { return "timeScale = " + timeScale.ToString(); }
        }
        protected override void OnExecute()
        {
            Time.timeScale = timeScale.value;

            if (adjustFixedDeltaTime.value)
            {
                //TODO: how to get the user set default value?
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
            EndAction();
        }       
    }
}