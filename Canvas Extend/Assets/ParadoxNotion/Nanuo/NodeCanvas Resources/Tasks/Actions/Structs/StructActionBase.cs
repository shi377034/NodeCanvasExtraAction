using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("✫ Structs")]
	public abstract class StructActionBase : ActionTask{
        [RequiredField]
        [SerializeField]
        public BBParameter<Struct> Struct;
        public Struct currentInstance
        {
            get { return Struct.value; }
            set { Struct.value = value; }
        }
        protected override string OnInit()
        {
            if(!Struct.value.IsInstance && !Struct.value.IsStatic)
            {
                currentInstance = Struct.value.Clone();
            }
            return null;
        }
    }
}