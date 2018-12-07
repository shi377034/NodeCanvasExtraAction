using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertFloatToInt : ActionTask
    {
        public enum FloatRounding
        {
            RoundDown,
            RoundUp,
            Nearest
        }

        public BBParameter<float> floatVariable;
        public BBParameter<FloatRounding> rounding;
        [BlackboardOnly]
        public BBParameter<int> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", floatVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute()
        {
            switch (rounding.value)
            {

                case FloatRounding.Nearest:
                    store.value = Mathf.RoundToInt(floatVariable.value);
                    break;

                case FloatRounding.RoundDown:
                    store.value = Mathf.FloorToInt(floatVariable.value);
                    break;

                case FloatRounding.RoundUp:
                    store.value = Mathf.CeilToInt(floatVariable.value);
                    break;
            }
            EndAction();
        }
    }
}