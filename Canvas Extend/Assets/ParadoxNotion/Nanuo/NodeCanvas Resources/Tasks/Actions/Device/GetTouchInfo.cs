using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class GetTouchInfo : ActionTask
    {
        public BBParameter<int> fingerId;
        public BBParameter<bool> normalize;
        [BlackboardOnly]
        public BBParameter<Vector3> storePosition;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<Vector3> storeDeltaPosition;
        [BlackboardOnly]
        public BBParameter<float> storeDeltaX;
        [BlackboardOnly]
        public BBParameter<float> storeDeltaY;
        [BlackboardOnly]
        public BBParameter<float> storeDeltaTime;
        [BlackboardOnly]
        public BBParameter<int> storeTapCount;
        float screenWidth;
        float screenHeight;
        protected override void OnExecute(){
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    if (touch.fingerId == fingerId.value)
                    {
                        float x = normalize.value == false ? touch.position.x : touch.position.x / screenWidth;
                        float y = normalize.value == false ? touch.position.y : touch.position.y / screenHeight;

                        storePosition.value = new Vector3(x, y, 0);

                        storeX.value = x;
                        storeY.value = y;

                        float deltax = normalize.value == false ? touch.deltaPosition.x : touch.deltaPosition.x / screenWidth;
                        float deltay = normalize.value == false ? touch.deltaPosition.y : touch.deltaPosition.y / screenHeight;

                        storeDeltaPosition.value = new Vector3(deltax, deltay, 0);

                        storeDeltaX.value = deltax;
                        storeDeltaY.value = deltay;

                        storeDeltaTime.value = touch.deltaTime;
                        storeTapCount.value = touch.tapCount;
                    }
                }
            }
            EndAction();
        }
    }
}