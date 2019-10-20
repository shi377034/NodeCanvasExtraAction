using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("Logic")]
    public class BoolOperator : ConditionTask
    {
        public enum Operation
        {
            AND,
            NAND,
            OR,
            XOR
        }

        public BBParameter<bool> valueA;
        public Operation checkType = Operation.AND;
        public BBParameter<bool> valueB;
        protected override string info
        {
            get { return GetCompareString(valueA.ToString(), checkType, valueB.ToString()); }
        }

        protected override bool OnCheck()
        {
            var v1 = valueA.value;
            var v2 = valueB.value;
            bool result = false;
            switch (checkType)
            {
                case Operation.AND:
                    result = v1 && v2;
                    break;
                case Operation.NAND:
                    result = !(v1 && v2);
                    break;
                case Operation.OR:
                    result = v1 || v2;
                    break;
                case Operation.XOR:
                    result = v1 ^ v2;
                    break;
            }
            return result;
        }

        string GetCompareString(string a,Operation cm,string b)
        {

            if (cm == Operation.AND)
                return a+ " && " + b;

            if (cm == Operation.NAND)
                return string.Format("!({0} && {1})",a,b);

            if (cm == Operation.OR)
                return a + " || " + b;

            if (cm == Operation.XOR)
                return a + " ^ " + b;

            return string.Empty;
        }
    }
}