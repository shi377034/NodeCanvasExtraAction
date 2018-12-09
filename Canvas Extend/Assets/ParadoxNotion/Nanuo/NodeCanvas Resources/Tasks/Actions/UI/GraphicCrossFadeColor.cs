using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("CrossFadeColor")]
    [Category("UI/Graphic")]
    public class GraphicCrossFadeColor : ActionTask<Graphic>
    {
        public BBParameter<Color> color;
        public BBParameter<float> duration;
        public BBParameter<bool> ignoreTimeScale;
        public BBParameter<bool> useAlpha;
        public BBParameter<bool> useRGB;
        protected override void OnExecute()
        {
            agent.CrossFadeColor(color.value, duration.value, ignoreTimeScale.value, useAlpha.value, useRGB.value);
            EndAction();
        }
    }
}