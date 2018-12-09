using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Time")]
    [Description("Gets various useful Time measurements.")]
    public class GetTimeInfo : ActionTask
    {
        public enum TimeInfo
        {
            DeltaTime,
            TimeScale,
            SmoothDeltaTime,
            TimeSinceStartup,
            TimeSinceLevelLoad,
            RealTimeSinceStartup,
        }
        public TimeInfo getInfo = TimeInfo.TimeSinceLevelLoad;
        [RequiredField]
        public BBParameter<float> storeValue;
        protected override string info
        {
            get { return storeValue + " = "+ getInfo.ToString(); }
        }
        protected override void OnExecute()
        {
            DoGetTimeInfo();
            EndAction();
        }
        void DoGetTimeInfo()
        {
            switch (getInfo)
            {
                case TimeInfo.DeltaTime:
                    storeValue.value = Time.deltaTime;
                    break;
                case TimeInfo.TimeScale:
                    storeValue.value = Time.timeScale;
                    break;
                case TimeInfo.SmoothDeltaTime:
                    storeValue.value = Time.smoothDeltaTime;
                    break;
                case TimeInfo.TimeSinceStartup:
                    storeValue.value = Time.time;
                    break;
                case TimeInfo.TimeSinceLevelLoad:
                    storeValue.value = Time.timeSinceLevelLoad;
                    break;
                case TimeInfo.RealTimeSinceStartup:
                    storeValue.value = Time.realtimeSinceStartup;
                    break;
                default:
                    storeValue.value = 0f;
                    break;
            }
        }
    }
}