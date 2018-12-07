using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Wait WWW")]
    [Category("WWW")]
    public class WWWObject : ActionTask
    {
        [RequiredField]
        public BBParameter<string> url;
        public BBParameter<string> isDoneEvent;
        public BBParameter<string> isErrorEvent;
        [BlackboardOnly]
        public BBParameter<string> storeText;
        [BlackboardOnly]
        public BBParameter<Texture> storeTexture;
        [BlackboardOnly]
        public BBParameter<string> errorString;
        [BlackboardOnly]
        public BBParameter<float> progress;
        private WWW wwwObject;
        protected override void OnExecute()
        {
            wwwObject = new WWW(url.value);
        }
        protected override void OnUpdate()
        {
            if (wwwObject == null)
            {
                errorString.value = "WWW Object is Null!";
                this.SendEvent(isErrorEvent.value);
                EndAction();
                return;
            }
            errorString.value = wwwObject.error;

            if (!string.IsNullOrEmpty(wwwObject.error))
            {
                EndAction();
                this.SendEvent(isErrorEvent.value);
                return;
            }

            progress.value = wwwObject.progress;

            if (progress.value.Equals(1f))
            {
                storeText.value = wwwObject.text;
                storeTexture.value = wwwObject.texture;
                errorString.value = wwwObject.error;
                this.SendEvent(string.IsNullOrEmpty(errorString.value) ? isDoneEvent.value : isErrorEvent.value);
                EndAction();
            }
        }
    }
}