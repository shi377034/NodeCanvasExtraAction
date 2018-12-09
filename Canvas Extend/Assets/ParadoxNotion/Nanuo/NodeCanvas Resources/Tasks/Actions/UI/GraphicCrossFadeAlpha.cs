using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("CrossFadeAlpha")]
    [Category("UI/Graphic")]
    public class GraphicCrossFadeAlpha : ActionTask<Graphic>
    {
        public BBParameter<float> alpha;
        public BBParameter<float> duration;
        public BBParameter<bool> ignoreTimeScale;
        protected override void OnExecute()
        {
            agent.CrossFadeAlpha(alpha.value, duration.value, ignoreTimeScale.value);
            EndAction();
        }
    }
}