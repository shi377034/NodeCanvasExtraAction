using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Texture")]
    [Category("UI/RawImage")]
    public class RawImageSetTexture : ActionTask<RawImage>
    {
        public BBParameter<Texture> texture;
        protected override void OnExecute()
        {
            agent.texture = texture.value;
            EndAction();
        }
    }
}