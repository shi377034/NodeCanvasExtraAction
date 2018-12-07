using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class SetQuaternion : ActionTask
    {
        public enum OperationMethod
        {
            MultiplyByQuaternion,
            MultiplyByVector,
        }
        [BlackboardOnly]
        public BBParameter<Quaternion> quaternionA;   
        public OperationMethod Operation = OperationMethod.MultiplyByQuaternion;
        [ShowIf("Operation", (int)OperationMethod.MultiplyByVector)]
        public BBParameter<Vector3> vector3B;
        [ShowIf("Operation", (int)OperationMethod.MultiplyByQuaternion)]
        public BBParameter<Quaternion> quaternionB;
        [BlackboardOnly]
        [ShowIf("Operation", (int)OperationMethod.MultiplyByVector)]
        public BBParameter<Vector3> result;
        [ShowIf("Operation",(int)OperationMethod.MultiplyByVector)]
        public bool perSecond;
        protected override string info
        {
            get
            {
                switch (Operation)
                {
                    case OperationMethod.MultiplyByQuaternion:
                        return string.Format("{0} * {1}", quaternionA, quaternionB);
                    case OperationMethod.MultiplyByVector:
                        return string.Format("{0} * {1} {2}", quaternionA, vector3B, perSecond ? "Per Second" : "");
                }
                return base.info;
            }
        }
        protected override void OnExecute()
        {
            switch(Operation)
            {
                case OperationMethod.MultiplyByQuaternion:
                    quaternionA.value = quaternionA.value * quaternionB.value;
                    break;
                case OperationMethod.MultiplyByVector:
                    Vector3 v = (vector3B.value * (perSecond ? UnityEngine.Time.deltaTime : 1f));
                    result.value = quaternionA.value * v;
                    break;
            } 
            EndAction();
        }
    }
}