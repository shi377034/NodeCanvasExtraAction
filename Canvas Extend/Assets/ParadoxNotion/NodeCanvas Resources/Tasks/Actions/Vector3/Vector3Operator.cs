using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector3")]
    public class Vector3Operator : ActionTask
    {
        public enum Vector3Operation
        {
            DotProduct = 1,
            CrossProduct = 2<<1,
            Distance = 2 << 2,
            Angle = 2 << 3,
            Project = 2 << 4,
            Reflect = 2 << 5,
            Min = 2 << 6,
            Max = 2 << 7,
            MultiplyFloat = 2 << 8,
            DivideFloat = 2 << 9,
        }
        public BBParameter<Vector3> vectorA;
        public Vector3Operation operation = Vector3Operation.Angle;
        [ShowIfEnum("operation", ~((int)Vector3Operation.MultiplyFloat | (int)Vector3Operation.DivideFloat))]
        public BBParameter<Vector3> vectorB;
        [ShowIfEnum("operation", (int)Vector3Operation.MultiplyFloat | (int)Vector3Operation.DivideFloat)]
        public BBParameter<float> floatB;
        [BlackboardOnly]
        [ShowIfEnum("operation", ~((int)Vector3Operation.DotProduct | (int)Vector3Operation.Distance | (int)Vector3Operation.Angle))]
        public BBParameter<Vector3> storeResult;
        [BlackboardOnly]
        [ShowIfEnum("operation",(int)Vector3Operation.DotProduct| (int)Vector3Operation.Distance| (int)Vector3Operation.Angle)]
        public BBParameter<float> storeFloatResult;
        protected override string info {
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
                case Vector3Operation.DotProduct:
                    storeFloatResult.value = Vector3.Dot(v1, v2);
                    break;
                case Vector3Operation.CrossProduct:
                    storeResult.value = Vector3.Cross(v1, v2);
                    break;
                case Vector3Operation.Distance:
                    storeFloatResult.value = Vector3.Distance(v1, v2);
                    break;
                case Vector3Operation.Angle:
                    storeFloatResult.value = Vector3.Angle(v1, v2);
                    break;
                case Vector3Operation.Project:
                    storeResult.value = Vector3.Project(v1, v2);
                    break;
                case Vector3Operation.Reflect:
                    storeResult.value = Vector3.Reflect(v1, v2);
                    break;
                case Vector3Operation.Min:
                    storeResult.value = Vector3.Min(v1, v2);
                    break;
                case Vector3Operation.Max:
                    storeResult.value = Vector3.Max(v1, v2);
                    break;
                case Vector3Operation.MultiplyFloat:
                    storeResult.value = v1 * floatB.value;
                    break;
                case Vector3Operation.DivideFloat:
                    storeResult.value = v1 / floatB.value;
                    break;
            }
            EndAction();
        }
        string GetOperationString(Vector3Operation operation)
        {
            switch (operation)
            {
                case Vector3Operation.DotProduct:
                    return string.Format("{0} = Dot({1},{2})", storeFloatResult, vectorA, vectorB);
                case Vector3Operation.CrossProduct:
                    return string.Format("{0} = Cross({1},{2})", storeResult, vectorA, vectorB);
                case Vector3Operation.Distance:
                    return string.Format("{0} = Distance({1},{2})", storeFloatResult, vectorA, vectorB);
                case Vector3Operation.Angle:
                    return string.Format("{0} = Angle({1},{2})", storeFloatResult, vectorA, vectorB);             
                case Vector3Operation.Project:
                    return string.Format("{0} = Project({1},{2})", storeResult, vectorA, vectorB);
                case Vector3Operation.Reflect:
                    return string.Format("{0} = Reflect({1},{2})", storeResult, vectorA, vectorB);
                case Vector3Operation.Min:
                    return string.Format("{0} = Min({1},{2})", storeResult, vectorA, vectorB);
                case Vector3Operation.Max:
                    return string.Format("{0} = Max({1},{2})", storeResult, vectorA, vectorB);
                case Vector3Operation.MultiplyFloat:
                    return string.Format("{0} = {1} * {2}", storeResult, vectorA, floatB);
                case Vector3Operation.DivideFloat:
                    return string.Format("{0} = {1} / {2}", storeResult, vectorA, floatB);
            }
            return "";
        }
    }
}