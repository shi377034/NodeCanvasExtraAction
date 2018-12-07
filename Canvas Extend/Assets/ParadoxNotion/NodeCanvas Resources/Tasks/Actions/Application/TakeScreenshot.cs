#if !(UNITY_FLASH || UNITY_METRO)
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Category("Application")]
    public class TakeScreenshot : ActionTask
    {
        public enum Destination
        {
            MyPictures,
            PersistentDataPath,
            CustomPath
        }
        [Tooltip("Where to save the screenshot.")]
        public BBParameter<Destination> destination;
        public BBParameter<string> customPath;
        public BBParameter<string> filename;
        public BBParameter<bool> autoNumber;
        public BBParameter<int> superSize;
        public BBParameter<bool> debugLog;
        private int screenshotCount;

        protected override void OnExecute()
        {
            if (string.IsNullOrEmpty(filename.value))
            {
                EndAction();
                return;
            }
            string screenshotPath;
            switch (destination.value)
            {
                case Destination.MyPictures:
                    screenshotPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    break;
                case Destination.PersistentDataPath:
                    screenshotPath = Application.persistentDataPath;
                    break;
                case Destination.CustomPath:
                    screenshotPath = customPath.value;
                    break;
                default:
                    screenshotPath = "";
                    break;
            }

            screenshotPath = screenshotPath.Replace("\\", "/") + "/";
            var screenshotFullPath = screenshotPath + filename.value + ".png";
            if (autoNumber.value)
            {
                while (System.IO.File.Exists(screenshotFullPath))
                {
                    screenshotCount++;
                    screenshotFullPath = screenshotPath + filename.value + screenshotCount + ".png";
                }
            }

            if (debugLog.value)
            {
                Debug.Log("TakeScreenshot: " + screenshotFullPath);
            }

#if UNITY_2017_1_OR_NEWER
            ScreenCapture.CaptureScreenshot(screenshotFullPath, superSize.value);
#else
            Application.CaptureScreenshot(screenshotFullPath, superSize.Value);
#endif
            EndAction();
        }
    }
}
#endif