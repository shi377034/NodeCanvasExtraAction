using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class CreateScene : ActionTask
    {
        [RequiredField]
        public BBParameter<string> sceneName;
        protected override void OnExecute()
        {
            SceneManager.CreateScene(sceneName.value);
            EndAction();
        }
    }
}