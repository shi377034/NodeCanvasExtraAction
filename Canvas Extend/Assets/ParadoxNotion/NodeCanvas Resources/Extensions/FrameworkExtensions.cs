using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NodeCanvas.Framework
{
    public static class FrameworkExtensions
    {
        public static int RandomWeightedIndex(this List<float> weights)
        {
            float totalWeight = 0;
            foreach (var t in weights)
            {
                totalWeight += t;
            }
            var random = Random.Range(0, totalWeight);
            for (var i = 0; i < weights.Count; i++)
            {
                if (random < weights[i])
                {
                    return i;
                }

                random -= weights[i];
            }
            return -1;
        }
        public static int RandomWeightedIndex(this float[] weights)
        {
            float totalWeight = 0;
            foreach (var t in weights)
            {
                totalWeight += t;
            }
            var random = Random.Range(0, totalWeight);
            for (var i = 0; i < weights.Length; i++)
            {
                if (random < weights[i])
                {
                    return i;
                }

                random -= weights[i];
            }
            return -1;
        }
        public static void SendEvent(this Task task, string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            task.SendEvent(new ParadoxNotion.EventData(name));
        }
        public static void SendEvent<T>(this Task task, string name, T value)
        {
            if (string.IsNullOrEmpty(name)) return;
            task.SendEvent(new ParadoxNotion.EventData<T>(name, value));
        }
        public static void SendEvent(this Task task, ParadoxNotion.EventData eventData)
        {
            if (task.ownerSystem == null) return;
            task.ownerSystem.SendEvent(eventData, task);
        }
    }
}