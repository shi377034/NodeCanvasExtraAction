using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set FillAmount")]
    [Category("UI/Image")]
    public class ImageSetFillAmount : ActionTask<Image>
    {
        public BBParameter<float> fillAmount;
        protected override void OnExecute()
        {
            agent.fillAmount = fillAmount.value;
            EndAction();
        }
    }
}