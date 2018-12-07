using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Name("LoadScene")]
    [Category("Scene")]
    public class LoadSceneSuper : ActionTask
    {
        public enum SceneSimpleReferenceOptions { SceneAtIndex, SceneByName };
        public SceneSimpleReferenceOptions sceneReference = SceneSimpleReferenceOptions.SceneByName;
        [ShowIf("sceneReference",(int)SceneSimpleReferenceOptions.SceneByName)]
        public BBParameter<string> sceneByName;
        [ShowIf("sceneReference", (int)SceneSimpleReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sceneAtIndex;
        public BBParameter<LoadSceneMode> loadSceneMode;
        protected override void OnExecute()
        {
            switch(sceneReference)
            {
                case SceneSimpleReferenceOptions.SceneAtIndex:
                    if(SceneManager.GetActiveScene().buildIndex != sceneAtIndex.value)
                    {
                        SceneManager.LoadScene(sceneAtIndex.value,loadSceneMode.value);
                    }
                    break;
                case SceneSimpleReferenceOptions.SceneByName:
                    if(SceneManager.GetActiveScene().name != sceneByName.value)
                    {
                        SceneManager.LoadScene(sceneByName.value,loadSceneMode.value);
                    }
                    break;
            }
            EndAction();
        }
    }
}