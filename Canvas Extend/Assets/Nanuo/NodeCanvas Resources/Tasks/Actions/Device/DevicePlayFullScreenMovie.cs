using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class DevicePlayFullScreenMovie : ActionTask
    {
        public BBParameter<string> moviePath;
        public BBParameter<Color> fadeColor;
        public BBParameter<FullScreenMovieControlMode> movieControlMode;
        public BBParameter<FullScreenMovieScalingMode> movieScalingMode;
        protected override void OnExecute(){
            Handheld.PlayFullScreenMovie(moviePath.value, fadeColor.value, movieControlMode.value, movieScalingMode.value);
            EndAction();
        }
    }
}