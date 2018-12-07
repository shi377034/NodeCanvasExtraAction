using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Time")]
    [Description("Multiplies a Float by Time.deltaTime to use in frame-rate independent operations. E.g., 10 becomes 10 units per second.")]
    public class PerSecond : ActionTask
    {
        public BBParameter<float> floatValue;
        [BlackboardOnly]
        public BBParameter<float> storeResult;
        protected override string info
        {
            get { return storeResult + " = " + floatValue + " * Time.deltaTime"; }
        }
        protected override void OnExecute()
        {
            storeResult.value = floatValue.value * Time.deltaTime;
            EndAction();
        }
    }
}