using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Sprite")]
    [Category("UI/Image")]
    public class ImageSetSprite : ActionTask<Image>
    {
        public BBParameter<Sprite> sprite;
        protected override void OnExecute()
        {
            agent.sprite = sprite.value;
            EndAction();
        }
    }
}