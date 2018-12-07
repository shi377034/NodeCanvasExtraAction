using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Color")]
    [Category("UI/Graphic")]
    public class GraphicSetColor : ActionTask<Graphic>
    {
        public BBParameter<Color> color;
        protected override void OnExecute()
        {
            agent.color = color.value;
            EndAction();
        }
    }
}