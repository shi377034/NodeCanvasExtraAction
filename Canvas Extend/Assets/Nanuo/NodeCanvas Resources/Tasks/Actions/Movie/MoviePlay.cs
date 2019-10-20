using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{

    [Category("Movie")]
    public class MoviePlay : ActionTask<VideoPlayer>
    {
        public enum VideoRenderMode
        {
            CameraFarPlane = 1,
            CameraNearPlane = 2 << 1,
            RenderTexture = 2 << 2,
            MaterialOverride = 2 << 3,
            APIOnly = 2 << 4,
        }
        public VideoSource source;
        [ShowIf("source", (int)VideoSource.VideoClip)]
        public BBParameter<VideoClip> videoClip;
        [ShowIf("source", (int)VideoSource.Url)]
        public BBParameter<string> url;
        public BBParameter<bool> waitForFirstFrame;
        public BBParameter<bool> playOnAwake;
        public BBParameter<bool> isLooping;
        [SliderField(0,10f)]
        public BBParameter<float> playbackSpeed = 1f;     
        public VideoRenderMode renderMode = VideoRenderMode.RenderTexture;
        [ShowIf("renderMode", (int)VideoRenderMode.RenderTexture)]
        public BBParameter<RenderTexture> targetTexture;
        [ShowIfEnum("renderMode", (int)VideoRenderMode.CameraNearPlane | (int)VideoRenderMode.CameraFarPlane)]
        [Name("Camera")]
        public BBParameter<Camera> targetCamera;
        [ShowIfEnum("renderMode", (int)VideoRenderMode.CameraNearPlane | (int)VideoRenderMode.CameraFarPlane)]
        [SliderField(0,1f)]
        [Name("Alpha")]
        public BBParameter<float> alpha = 1f;
        [ShowIf("renderMode", (int)VideoRenderMode.MaterialOverride)] 
        public BBParameter<Renderer> targetRenderer;
        [ShowIf("renderMode", (int)VideoRenderMode.MaterialOverride)]
        [TexturePropertyName("targetRenderer")]
        public BBParameter<string> targetMaterialProperty;
        [ShowIfEnum("renderMode", (int)VideoRenderMode.CameraFarPlane | (int)VideoRenderMode.CameraNearPlane | (int)VideoRenderMode.RenderTexture)]
        public VideoAspectRatio aspectRatio = VideoAspectRatio.FitHorizontally;
        public VideoAudioOutputMode audioOutputMode = VideoAudioOutputMode.Direct;
        [ShowIf("audioOutputMode", (int)VideoAudioOutputMode.AudioSource)]
        public BBParameter<AudioSource> audioSource;
        protected override void OnExecute()
        {
            switch (source)
            {
                case VideoSource.VideoClip:
                    agent.clip = videoClip.value;
                    break;
                case VideoSource.Url:
                    agent.url = url.value;
                    break;
            }
            agent.source = source;
            agent.waitForFirstFrame = waitForFirstFrame.value;
            agent.playOnAwake = playOnAwake.value;
            agent.playbackSpeed = playbackSpeed.value;
            agent.isLooping = isLooping.value;
            agent.audioOutputMode = audioOutputMode;
            
            switch (renderMode)
            {
                case VideoRenderMode.RenderTexture:
                    agent.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
                    agent.targetTexture = targetTexture.value;
                    break;
                case VideoRenderMode.CameraFarPlane:
                    agent.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
                    agent.targetCamera = targetCamera.value;
                    agent.targetCameraAlpha = alpha.value;
                    break;
                case VideoRenderMode.CameraNearPlane:
                    agent.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
                    agent.targetCamera = targetCamera.value;
                    agent.targetCameraAlpha = alpha.value;
                    break;
                case VideoRenderMode.MaterialOverride:
                    agent.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
                    agent.targetMaterialRenderer = targetRenderer.value;
                    agent.targetMaterialProperty = targetMaterialProperty.value;
                    break;
                case VideoRenderMode.APIOnly:
                    break;
            }
            switch (audioOutputMode)
            {
                case VideoAudioOutputMode.AudioSource:
                    agent.SetTargetAudioSource(0, audioSource.value);
                    agent.IsAudioTrackEnabled(0);
                    break;
            }
            if (!agent.gameObject.activeSelf)
            {
                agent.gameObject.SetActive(true);
            }
            if (!agent.enabled)
            {
                agent.enabled = true;
            }
            agent.Play();
            EndAction();
        }
    }
}