using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class ProjectLocationToMap : ActionTask
    {
        public enum MapProjection
        {
            EquidistantCylindrical,
            Mercator
        }
        public BBParameter<Vector3> GPSLocation;
        public BBParameter<MapProjection> mapProjection;
        [Header("Map Region")]
        [SliderField(-180f,180f)]
        public BBParameter<float> minLongitude = -180f;
        [SliderField(-180f, 180f)]
        public BBParameter<float> maxLongitude = 180f;
        [SliderField(-90f, 90f)]
        public BBParameter<float> minLatitude = -90f;
        [SliderField(-90f, 90f)]
        public BBParameter<float> maxLatitude = 90f;
        [Header("Screen Region")]
        public BBParameter<float> minX;
        public BBParameter<float> minY;
        public BBParameter<float> width = 1f;
        public BBParameter<float> height = 1f;
        [Header("Projection")]
        [BlackboardOnly]
        public BBParameter<float> projectedX;
        [BlackboardOnly]
        public BBParameter<float> projectedY;
        public BBParameter<bool> normalized = true;
        private float x, y;
        protected override void OnExecute(){
            x = Mathf.Clamp(GPSLocation.value.x, minLongitude.value, maxLongitude.value);
            y = Mathf.Clamp(GPSLocation.value.y, minLatitude.value, maxLatitude.value);

            // projection methods should produce normalized coordinates inside the map region

            switch (mapProjection.value)
            {
                case MapProjection.EquidistantCylindrical:
                    DoEquidistantCylindrical();
                    break;

                case MapProjection.Mercator:
                    DoMercatorProjection();
                    break;
            }

            x *= width.value;
            y *= height.value;

            projectedX.value = normalized.value ? minX.value + x : minX.value + x * Screen.width;
            projectedY.value = normalized.value ? minY.value + y : minY.value + y * Screen.height;
            EndAction();
        }
        void DoEquidistantCylindrical()
        {
            x = (x - minLongitude.value) / (maxLongitude.value - minLongitude.value);
            y = (y - minLatitude.value) / (maxLatitude.value - minLatitude.value);
        }

        void DoMercatorProjection()
        {
            x = (x - minLongitude.value) / (maxLongitude.value - minLongitude.value);

            var minYProjected = LatitudeToMercator(minLatitude.value);
            var maxYProjected = LatitudeToMercator(maxLatitude.value);

            y = (LatitudeToMercator(GPSLocation.value.y) - minYProjected) / (maxYProjected - minYProjected);
        }

        static float LatitudeToMercator(float latitudeInDegrees)
        {
            var lat = Mathf.Clamp(latitudeInDegrees, -85, 85);
            lat = Mathf.Deg2Rad * lat;
            return Mathf.Log(Mathf.Tan(lat / 2f + Mathf.PI / 4f));
        }
    }
}