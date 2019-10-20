using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class AllowSceneActivation : ActionTask
    {
        public BBParameter<int> aSynchOperationHashCode;
        public BBParameter<bool> allowSceneActivation = true;
        public BBParameter<string> doneEvent;
        public BBParameter<string> failureEvent;
        [BlackboardOnly]
        public BBParameter<float> progress;
        [BlackboardOnly]
        public BBParameter<bool> isDone;
        protected override void OnExecute()
        {
            DoAllowSceneActivation();
        }
        protected override void OnUpdate()
        {
            progress.value = LoadSceneAsynch.aSyncOperationLUT[aSynchOperationHashCode.value].progress;

            isDone.value = LoadSceneAsynch.aSyncOperationLUT[aSynchOperationHashCode.value].isDone;

            if (LoadSceneAsynch.aSyncOperationLUT[aSynchOperationHashCode.value].isDone)
            {
                LoadSceneAsynch.aSyncOperationLUT.Remove(aSynchOperationHashCode.value);
                this.SendEvent(doneEvent.value);
                EndAction();
                return;
            }
        }
        void DoAllowSceneActivation()
        {
            if (LoadSceneAsynch.aSyncOperationLUT == null ||
                !LoadSceneAsynch.aSyncOperationLUT.ContainsKey(aSynchOperationHashCode.value)
            )
            {
                this.SendEvent(failureEvent.value);
                EndAction();
                return;
            }

            LoadSceneAsynch.aSyncOperationLUT[aSynchOperationHashCode.value].allowSceneActivation = allowSceneActivation.value;
        }
    }
}