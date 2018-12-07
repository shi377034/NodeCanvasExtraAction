using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class Vector2Operator : ActionTask
    {
        public enum Vector2Operation
        {
            DotProduct = 1,
            Distance = 2<<1,
            Angle = 2 << 2,
            Min = 2 << 3,
            Max = 2 << 4,
            MultiplyFloat = 2 << 5,
            DivideFloat = 2 << 6,
        }
        public BBParameter<Vector2> vectorA;
        public Vector2Operation operation = Vector2Operation.Angle;
        [ShowIfEnum("operation", ~((int)Vector2Operation.MultiplyFloat | (int)Vector2Operation.DivideFloat))]
        public BBParameter<Vector2> vectorB;
        [ShowIfEnum("operation", (int)Vector2Operation.MultiplyFloat | (int)Vector2Operation.DivideFloat)]
        public BBParameter<float> floatB;
        [BlackboardOnly]
        [ShowIfEnum("operation", ~((int)Vector2Operation.DotProduct | (int)Vector2Operation.Distance | (int)Vector2Operation.Angle))]
        public BBParameter<Vector2> storeResult;
        [BlackboardOnly]
        [ShowIfEnum("operation", (int)Vector2Operation.DotProduct | (int)Vector2Operation.Distance | (int)Vector2Operation.Angle)]
        public BBParameter<float> storeFloatResult;
        protected override string info
        {
            get
            {
                return GetOperationString(operation);
            }
        }
        protected override void OnExecute()
        {
            var v1 = vectorA.value;
            var v2 = vectorB.value;

            switch (operation)
            {
                case Vector2Operation.DotProduct:
                    storeFloatResult.value = Vector2.Dot(v1, v2);
                    break;
                case Vector2Operation.Distance:
                    storeFloatResult.value = Vector2.Distance(v1, v2);
                    break;
                case Vector2Operation.Angle:
                    storeFloatResult.value = Vector2.Angle(v1, v2);
                    break;
                case Vector2Operation.Min:
                    storeResult.value = Vector2.Min(v1, v2);
                    break;
                case Vector2Operation.Max:
                    storeResult.value = Vector2.Max(v1, v2);
                    break;
                case Vector2Operation.MultiplyFloat:
                    storeResult.value = v1 * floatB.value;
                    break;
                case Vector2Operation.DivideFloat:
                    storeResult.value = v1 / floatB.value;
                    break;
            }
            EndAction();
        }
        string GetOperationString(Vector2Operation operation)
        {
            switch (operation)
            {
                case Vector2Operation.DotProduct:
                    return string.Format("{0} = Dot({1},{2})", storeFloatResult, vectorA, vectorB);
                case Vector2Operation.Distance:
                    return string.Format("{0} = Distance({1},{2})", storeFloatResult, vectorA, vectorB);
                case Vector2Operation.Angle:
                    return string.Format("{0} = Angle({1},{2})", storeFloatResult, vectorA, vectorB);
                case Vector2Operation.Min:
                    return string.Format("{0} = Min({1},{2})", storeResult, vectorA, vectorB);
                case Vector2Operation.Max:
                    return string.Format("{0} = Max({1},{2})", storeResult, vectorA, vectorB);
                case Vector2Operation.MultiplyFloat:
                    return string.Format("{0} = {1} * {2}", storeResult, vectorA, floatB);
                case Vector2Operation.DivideFloat:
                    return string.Format("{0} = {1} / {2}", storeResult, vectorA, floatB);
            }
            return "";
        }
    }
}