using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
    [Category("Convert")]
    public class ConvertEnumToString : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<System.Enum> enumVariable;
        [BlackboardOnly]
        public BBParameter<string> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", enumVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute(){
            store.value = enumVariable.value != null ? enumVariable.value.ToString() : string.Empty;
            EndAction();
        }
    }
}