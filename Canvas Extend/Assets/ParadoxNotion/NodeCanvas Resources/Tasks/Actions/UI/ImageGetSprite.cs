using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Sprite")]
    [Category("UI/Image")]
    public class ImageGetSprite : ActionTask<Image>
    {
        [BlackboardOnly]
        public BBParameter<Sprite> sprite;
        protected override void OnExecute()
        {
            sprite.value = agent.sprite;
            EndAction();
        }
    }
}