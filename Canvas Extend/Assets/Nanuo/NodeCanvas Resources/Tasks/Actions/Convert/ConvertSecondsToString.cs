using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertSecondsToString : ActionTask
    {
        public BBParameter<float> seconds;
        public BBParameter<string> format = "{1:D2}h:{2:D2}m:{3:D2}s:{10}ms";
        [BlackboardOnly]
        public BBParameter<string> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", seconds.ToString(),store.ToString());
            }
        }
        protected override void OnExecute()
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(seconds.value);
            string milliseconds_2D = t.Milliseconds.ToString("D3").PadLeft(2, '0');
            milliseconds_2D = milliseconds_2D.Substring(0, 2);
            store.value = string.Format(format.value,
                        t.Days,
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds,
                        t.TotalDays,
                        t.TotalHours,
                        t.TotalMinutes,
                        t.TotalSeconds,
                        t.TotalMilliseconds,
                        milliseconds_2D);
            EndAction();
        }
    }
}