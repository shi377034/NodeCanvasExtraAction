using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Color")]
    [Category("UI/Graphic")]
    public class GraphicGetColor : ActionTask<Graphic>
    {
        [BlackboardOnly]
        public BBParameter<Color> color;
        protected override void OnExecute()
        {
            color.value = agent.color;
            EndAction();
        }
    }
}