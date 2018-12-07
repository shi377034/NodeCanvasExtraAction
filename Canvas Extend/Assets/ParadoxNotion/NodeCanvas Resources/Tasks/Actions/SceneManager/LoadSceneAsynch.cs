using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Name("LoadSceneAsync")]
    [Category("Scene")]
    public class LoadSceneAsynch : ActionTask
    {
        public enum SceneSimpleReferenceOptions { SceneAtIndex, SceneByName };
        public SceneSimpleReferenceOptions sceneReference = SceneSimpleReferenceOptions.SceneByName;
        [ShowIf("sceneReference",(int)SceneSimpleReferenceOptions.SceneByName)]
        public BBParameter<string> sceneByName;
        [ShowIf("sceneReference", (int)SceneSimpleReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sceneAtIndex;
        public BBParameter<LoadSceneMode> loadSceneMode;
        public BBParameter<bool> allowSceneActivation;
        public BBParameter<int> operationPriority;
        public BBParameter<string> doneEvent;
        public BBParameter<string> pendingActivationEvent;
        public BBParameter<string> sceneNotFoundEvent;
        [BlackboardOnly]
        public BBParameter<int> aSyncOperationHashCode;
        [BlackboardOnly]
        public BBParameter<float> progress;
        [BlackboardOnly]
        public BBParameter<bool> isDone;
        [BlackboardOnly]
        public BBParameter<bool> pendingActivation;

        AsyncOperation _asyncOperation;
        int _asynchOperationUid = -1;
        bool pendingActivationCallBackDone;


        public static Dictionary<int, AsyncOperation> aSyncOperationLUT;
        static int aSynchUidCounter = 0;
        protected override void OnExecute()
        {
            pendingActivationCallBackDone = false;
            pendingActivation.value = false;
            isDone.value = false;
            progress.value = 0f;
            bool _result = DoLoadAsynch();
            if (!_result)
            {
                this.SendEvent(sceneNotFoundEvent.value);
                EndAction();
            }
        }
        bool DoLoadAsynch()
        {
            if (sceneReference == SceneSimpleReferenceOptions.SceneAtIndex)
            {
                if (SceneManager.GetActiveScene().buildIndex == sceneAtIndex.value)
                {
                    return false;
                }
                else
                {
                    _asyncOperation = SceneManager.LoadSceneAsync(sceneAtIndex.value, loadSceneMode.value);
                }

            }
            else
            {
                if (SceneManager.GetActiveScene().name == sceneByName.value)
                {
                    return false;
                }
                else
                {
                    _asyncOperation = SceneManager.LoadSceneAsync(sceneByName.value,loadSceneMode.value);
                }
            }

            _asyncOperation.priority = operationPriority.value;

            _asyncOperation.allowSceneActivation = allowSceneActivation.value;

            if (aSyncOperationLUT == null)
            {
                aSyncOperationLUT = new Dictionary<int, AsyncOperation>();
            }
            _asynchOperationUid = ++aSynchUidCounter;
            aSyncOperationHashCode.value = _asynchOperationUid;
            aSyncOperationLUT.Add(_asynchOperationUid, _asyncOperation);
            return true;
        }
        protected override void OnUpdate()
        {
            if (_asyncOperation == null)
            {
                EndAction();
                return;
            }

            if (_asyncOperation.isDone)
            {
                isDone.value = true;
                progress.value = _asyncOperation.progress;

                if (aSyncOperationLUT != null && _asynchOperationUid != -1)
                {
                    aSyncOperationLUT.Remove(_asynchOperationUid);
                }

                _asyncOperation = null;

                this.SendEvent(doneEvent.value);
                EndAction();

            }
            else
            {

                progress.value = _asyncOperation.progress;

                if (_asyncOperation.allowSceneActivation == false && allowSceneActivation.value)
                {
                    _asyncOperation.allowSceneActivation = true;
                }

                if (_asyncOperation.progress == 0.9f && _asyncOperation.allowSceneActivation == false && !pendingActivationCallBackDone)
                {

                    pendingActivationCallBackDone = true;
                    pendingActivation.value = true;

                    this.SendEvent(pendingActivationEvent.value);
                }

            }
        }
    }
}