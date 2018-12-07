using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("Quaternion")]
    public class QuaternionCompare : ConditionTask
    {
        public enum CompareMethod
        {
            EqualTo,
            NotEqualTo
        }
        public BBParameter<Quaternion> quaternionA;
        public CompareMethod checkType;
        public BBParameter<Quaternion> quaternionB;
        protected override string info
        {
            get { return string.Format("{0} {1} {2}", quaternionA, GetCompareString(checkType), quaternionB); }
        }

        protected override bool OnCheck()
        {
            switch (checkType)
            {
                case CompareMethod.EqualTo:
                    return quaternionA.value == quaternionB.value;
                case CompareMethod.NotEqualTo:
                    return quaternionA.value != quaternionB.value;
            }
            return false;
        }
        string GetCompareString(CompareMethod compare)
        {
            switch (compare)
            {
                case CompareMethod.EqualTo:
                    return "==";
                case CompareMethod.NotEqualTo:
                    return "!=";
            }
            return string.Empty;
        }

    }
}