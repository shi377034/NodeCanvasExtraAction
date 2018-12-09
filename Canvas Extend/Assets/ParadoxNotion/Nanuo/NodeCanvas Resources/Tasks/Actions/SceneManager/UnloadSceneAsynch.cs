using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class UnloadSceneAsynch : ActionTask
    {
        public enum SceneReferenceOptions { ActiveScene, SceneAtBuildIndex, SceneAtIndex, SceneByName, SceneByPath, SceneByGameObject };

        public SceneReferenceOptions sceneReference = SceneReferenceOptions.SceneByName;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneByName)]
        public BBParameter<string> sceneByName;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneAtBuildIndex)]
        public BBParameter<int> sceneAtBuildIndex;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sceneAtIndex;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneByPath)]
        public BBParameter<string> sceneByPath;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneByGameObject)]
        public BBParameter<GameObject> sceneByGameObject;
        public BBParameter<int> operationPriority;
        public BBParameter<string> doneEvent;
        public BBParameter<string> sceneNotFoundEvent;
        [BlackboardOnly]
        public BBParameter<float> progress;
        [BlackboardOnly]
        public BBParameter<bool> isDone;

        AsyncOperation _asyncOperation;
        protected override void OnExecute()
        {
            isDone.value = false;
            progress.value = 0f;
            bool _result = DoUnLoadAsynch();

            if (!_result)
            {
                this.SendEvent(sceneNotFoundEvent.value);
                EndAction();
            }
           
        }
        bool DoUnLoadAsynch()
        {
            switch (sceneReference)
            {
                case SceneReferenceOptions.ActiveScene:

                    _asyncOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

                    break;
                case SceneReferenceOptions.SceneAtBuildIndex:
                    _asyncOperation = SceneManager.UnloadSceneAsync(sceneAtBuildIndex.value);
                    break;
                case SceneReferenceOptions.SceneAtIndex:

                    _asyncOperation = SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(sceneAtIndex.value));

                    break;
                case SceneReferenceOptions.SceneByName:
                    _asyncOperation = SceneManager.UnloadSceneAsync(sceneByName.value);
                    break;
                case SceneReferenceOptions.SceneByPath:
                    _asyncOperation = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByPath(sceneByPath.value));
                    break;
                case SceneReferenceOptions.SceneByGameObject:
                    GameObject _go = sceneByGameObject.value;
                    _asyncOperation = SceneManager.UnloadSceneAsync(_go.scene);
                    break;
            }

            _asyncOperation.priority = operationPriority.value;

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

                _asyncOperation = null;

                this.SendEvent(doneEvent.value);
                EndAction();
            }
            else
            {
                progress.value = _asyncOperation.progress;
            }
        }
    }
}