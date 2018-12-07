using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class MergeScenes : ActionTask
    {
        public enum SceneAllReferenceOptions { ActiveScene, SceneAtIndex, SceneByName, SceneByPath, SceneByGameObject };
        public SceneAllReferenceOptions sourceReference = SceneAllReferenceOptions.SceneByName;
        [ShowIf("sourceReference",(int)SceneAllReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sourceAtIndex;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByName)]
        public BBParameter<string> sourceByName;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByPath)]
        public BBParameter<string> sourceByPath;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByGameObject)]
        public BBParameter<GameObject> sourceByGameObject;
        public SceneAllReferenceOptions destinationReference = SceneAllReferenceOptions.ActiveScene;
        [ShowIf("destinationReference", (int)SceneAllReferenceOptions.SceneAtIndex)]
        public BBParameter<int> destinationAtIndex;
        [ShowIf("destinationReference", (int)SceneAllReferenceOptions.SceneByName)]
        public BBParameter<string> destinationByName;
        [ShowIf("destinationReference", (int)SceneAllReferenceOptions.SceneByPath)]
        public BBParameter<string> destinationByPath;
        [ShowIf("destinationReference", (int)SceneAllReferenceOptions.SceneByGameObject)]
        public BBParameter<GameObject> destinationByGameObject;
        public BBParameter<string> successEvent;
        public BBParameter<string> failureEvent;
        [BlackboardOnly]
        public BBParameter<bool> success;

        Scene _sourceScene;
        bool _sourceFound;

        Scene _destinationScene;
        bool _destinationFound;
        protected override void OnExecute()
        {
            GetSourceScene();
            GetDestinationScene();
            if (_destinationFound && _sourceFound)
            {

                if (_destinationScene.Equals(_sourceScene))
                {
                    Debug.LogWarning("Source and Destination scenes can not be the same");
                    success.value = false;
                    this.SendEvent(failureEvent.value);
                    EndAction();
                    return;
                }
                else
                {
                    SceneManager.MergeScenes(_sourceScene, _destinationScene);
                }
                success.value = true;
                this.SendEvent(successEvent.value);
            }
            else
            {
                success.value = false;
                this.SendEvent(failureEvent.value);
            }
            EndAction();
        }
        void GetSourceScene()
        {
            switch (sourceReference)
            {
                case SceneAllReferenceOptions.ActiveScene:
                    _sourceScene = SceneManager.GetActiveScene();
                    break;
                case SceneAllReferenceOptions.SceneAtIndex:
                    _sourceScene = SceneManager.GetSceneAt(sourceAtIndex.value);
                    break;
                case SceneAllReferenceOptions.SceneByName:
                    _sourceScene = SceneManager.GetSceneByName(sourceByName.value);
                    break;
                case SceneAllReferenceOptions.SceneByPath:
                    _sourceScene = SceneManager.GetSceneByPath(sourceByPath.value);
                    break;
                case SceneAllReferenceOptions.SceneByGameObject:
                    _sourceScene = sourceByGameObject.value.scene;
                    break;
            }

            if (_sourceScene == new Scene())
            {
                _sourceFound = false;
            }
            else
            {
                _sourceFound = true;
            }
        }
        void GetDestinationScene()
        {
            switch (sourceReference)
            {
                case SceneAllReferenceOptions.ActiveScene:
                    _destinationScene = SceneManager.GetActiveScene();
                    break;
                case SceneAllReferenceOptions.SceneAtIndex:
                    _destinationScene = SceneManager.GetSceneAt(destinationAtIndex.value);
                    break;
                case SceneAllReferenceOptions.SceneByName:
                    _destinationScene = SceneManager.GetSceneByName(destinationByName.value);
                    break;
                case SceneAllReferenceOptions.SceneByPath:
                    _destinationScene = SceneManager.GetSceneByPath(destinationByPath.value);
                    break;
                case SceneAllReferenceOptions.SceneByGameObject:
                    _destinationScene = destinationByGameObject.value.scene;
                    break;
            }

            if (_destinationScene == new Scene())
            {
                _destinationFound = false;
            }
            else
            {
                _destinationFound = true;
            }
        }
    }
}