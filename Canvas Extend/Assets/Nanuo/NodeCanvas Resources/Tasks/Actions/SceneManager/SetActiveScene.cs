using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class SetActiveScene : ActionTask
    {
        public enum SceneReferenceOptions { SceneAtBuildIndex, SceneAtIndex, SceneByName, SceneByPath, SceneByGameObject };
        public SceneReferenceOptions sceneReference = SceneReferenceOptions.SceneByName;
        [ShowIf("sceneReference",(int)SceneReferenceOptions.SceneByName)]
        public BBParameter<string> sceneByName;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneAtBuildIndex)]
        public BBParameter<int> sceneAtBuildIndex;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sceneAtIndex;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneByPath)]
        public BBParameter<string> sceneByPath;
        [ShowIf("sceneReference", (int)SceneReferenceOptions.SceneByGameObject)]
        public BBParameter<GameObject> sceneByGameObject;
        public BBParameter<string> successEvent;
        public BBParameter<string> sceneNotActivatedEvent;
        public BBParameter<string> sceneNotFoundEvent;
        [BlackboardOnly]
        public BBParameter<bool> success;
        public BBParameter<bool> sceneFound;
        Scene _scene;
        bool _sceneFound;
        bool _success;
        protected override void OnExecute()
        {
            DoSetActivate();

            success.value = _success;

            sceneFound.value = _sceneFound;

            if (_success)
            {
                this.SendEvent(successEvent.value);
            }
            EndAction();
        }
        void DoSetActivate()
        {
            switch (sceneReference)
            {
                case SceneReferenceOptions.SceneAtIndex:
                    _scene = SceneManager.GetSceneAt(sceneAtIndex.value);
                    break;
                case SceneReferenceOptions.SceneByName:
                    _scene = SceneManager.GetSceneByName(sceneByName.value);
                    break;
                case SceneReferenceOptions.SceneByPath:
                    _scene = SceneManager.GetSceneByPath(sceneByPath.value);
                    break;
                case SceneReferenceOptions.SceneByGameObject:
                    GameObject _go = sceneByGameObject.value;
                    _scene = _go.scene;
                    break;
            }

            if (_scene == new Scene())
            {
                _sceneFound = false;
                this.SendEvent(sceneNotFoundEvent.value);
            }
            else
            {
                _success = SceneManager.SetActiveScene(_scene);
                _sceneFound = true;
            }
        }
    }
}