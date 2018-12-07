using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Category("Audio")]
    public class PlayAtPoint : ActionTask
    {
        public BBParameter<GameObject> target;
        public BBParameter<Vector3> position;
        [SliderField(0, 1f)]
        public BBParameter<float> volume = 1f;
        public BBParameter<AudioClip> oneShotClip;
        protected override string info
        {
            get { return string.Format("Play Audio {0} At Point" ,oneShotClip); }
        }

        protected override void OnExecute()
        {
            if (target.value == null)
            {
                AudioSource.PlayClipAtPoint(oneShotClip.value, position.value, volume.value);
            }
            else
            {
                AudioSource.PlayClipAtPoint(oneShotClip.value, target.value.transform.position + position.value, volume.value);
            }
            EndAction();
        }
    }
}