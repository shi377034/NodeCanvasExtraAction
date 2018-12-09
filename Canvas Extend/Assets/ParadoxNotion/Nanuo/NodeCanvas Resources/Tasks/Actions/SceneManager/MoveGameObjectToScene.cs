using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class MoveGameObjectToScene : ActionTask<GameObject>
    {
        public BBParameter<bool> findRootIfNecessary;
        [RequiredField]
        public BBParameter<Scene> scene;
        public BBParameter<string> successEvent;
        public BBParameter<string> failureEvent;
        [BlackboardOnly]
        public BBParameter<bool> success;
        GameObject _go;
        protected override void OnExecute()
        {
            _go = agent;

            if (findRootIfNecessary.value)
            {
                _go = _go.transform.root.gameObject;
            }

            if (_go.transform.parent == null)
            {
                SceneManager.MoveGameObjectToScene(_go, scene.value);
                success.value = true;
                this.SendEvent(successEvent.value);
            }
            else
            {

                Debug.LogWarning("GameObject must be a root ");
                success.value = false;
                this.SendEvent(failureEvent.value);
            }
            _go = null;
            EndAction();
        }
    }
}