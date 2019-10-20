using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("Logic")]
    public class ColorCompare : ConditionTask
    {
        public BBParameter<Color> valueA;
        public BBParameter<Color> valueB;
        [SliderField(0, 0.1f)]
        public float differenceThreshold = 0.05f;
        protected override string info
        {
            get { return valueA + " == " + valueB; }
        }
        protected override bool OnCheck()
        {
            if(OperationTools.Compare(valueA.value.r, valueB.value.r,CompareMethod.EqualTo, differenceThreshold)&&
               OperationTools.Compare(valueA.value.g, valueB.value.g, CompareMethod.EqualTo, differenceThreshold)&&
               OperationTools.Compare(valueA.value.b, valueB.value.b, CompareMethod.EqualTo, differenceThreshold)&&
               OperationTools.Compare(valueA.value.a, valueB.value.a, CompareMethod.EqualTo, differenceThreshold))
            {
                return true;
            }
            return false;
        }
    }
}