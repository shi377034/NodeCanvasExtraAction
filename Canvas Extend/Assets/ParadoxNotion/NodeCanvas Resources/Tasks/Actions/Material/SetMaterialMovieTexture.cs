using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;
using System.Collections;
namespace NodeCanvas.Tasks.Actions
{

    [Category("Material")]
    public class SetMaterialMovieTexture : ActionTask<Renderer>
    {
        public BBParameter<int> materialIndex;
        public BBParameter<Material> material;
        [RequiredField]
        public BBParameter<string> namedTexture = "_MainTex";
        [RequiredField]
        public BBParameter<VideoPlayer> videoPlayer;
        protected override void OnExecute()
        {
            if (material.value == null && agent.material == null)
            {
                Debug.LogError("Missing Material!");
                EndAction(false);
                return;
            }
            StartCoroutine(DoSetMaterialTexture(videoPlayer.value));
            EndAction();
        }
        IEnumerator DoSetMaterialTexture(VideoPlayer video)
        {
            var namedTex = namedTexture.value;
            if (namedTex == "") namedTex = "_MainTex";
            while ((ulong)video.frame < video.frameCount)
            {
                if (material.value != null)
                {
                    material.value.SetTexture(namedTex, video.texture);
                    break;
                }
                if (materialIndex.value == 0)
                {
                    agent.material.SetTexture(namedTex, video.texture);
                }
                else if (agent.materials.Length > materialIndex.value)
                {
                    var materials = agent.materials;
                    materials[materialIndex.value].SetTexture(namedTex, video.texture);
                    agent.materials = materials;
                }
                yield return null;
            }

        }

    }
}