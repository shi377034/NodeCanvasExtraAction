using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Texture")]
    [Category("UI/RawImage")]
    public class RawImageGetTexture : ActionTask<RawImage>
    {
        [BlackboardOnly]
        public BBParameter<Texture> texture;
        protected override void OnExecute()
        {
            texture.value = agent.texture;
            EndAction();
        }
    }
}