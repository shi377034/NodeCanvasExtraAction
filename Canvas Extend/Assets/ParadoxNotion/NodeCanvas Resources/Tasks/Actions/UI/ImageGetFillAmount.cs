using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get FillAmount")]
    [Category("UI/Image")]
    public class ImageGetFillAmount : ActionTask<Image>
    {
        [BlackboardOnly]
        public BBParameter<float> fillAmount;
        protected override void OnExecute()
        {
            fillAmount.value = agent.fillAmount;
            EndAction();
        }
    }
}