using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Game Volume")]
    [Category("Audio")]
    public class SetGameVolume : ActionTask
    {
        [SliderField(0,1f)]
        public BBParameter<float> volume;
        protected override string info
        {
            get { return "Global Sound Volume = " + volume.ToString(); }
        }

        protected override void OnExecute()
        {
            AudioListener.volume = volume.value;
            EndAction();
        }
    }
}