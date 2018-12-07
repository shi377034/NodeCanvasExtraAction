using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Device")]
	public class CheckSwipeGesture : ConditionTask{
        public enum SwipeTypes
        { 
            None,
            Left,
            Right,
            Up,
            Down
        }
        public BBParameter<float> minSwipeDistance = 0.1f;
        public BBParameter<SwipeTypes> swipeType = SwipeTypes.Up;

        float screenDiagonalSize;
        float minSwipeDistancePixels;
        bool touchStarted;
        Vector2 touchStartPos;
        protected override string info
        {
            get { return swipeType.ToString() + " Swipe"; }
        }

        protected override bool OnCheck(){
            screenDiagonalSize = Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
            minSwipeDistancePixels = minSwipeDistance.value * screenDiagonalSize;

            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        touchStarted = true;
                        touchStartPos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        if (touchStarted)
                        {
                            var swipe = TestForSwipeGesture(touch);
                            if(swipe == swipeType.value)
                            {
                                return true;
                            }
                            touchStarted = false;
                        }
                        break;
                    case TouchPhase.Canceled:
                        touchStarted = false;
                        break;
                    case TouchPhase.Stationary:
                        break;

                    case TouchPhase.Moved:
                        break;
                }
            }
            return false;
		}
        SwipeTypes TestForSwipeGesture(Touch touch)
        {
            // test min distance

            var lastPos = touch.position;
            var distance = Vector2.Distance(lastPos, touchStartPos);

            if (distance > minSwipeDistancePixels)
            {
                float dy = lastPos.y - touchStartPos.y;
                float dx = lastPos.x - touchStartPos.x;

                float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);

                angle = (360 + angle - 45) % 360;

                Debug.Log(angle);

                if (angle < 90)
                {
                    return SwipeTypes.Right;
                }
                else if (angle < 180)
                {
                    return SwipeTypes.Down;
                }
                else if (angle < 270)
                {
                    return SwipeTypes.Left;
                }
                else
                {
                    return SwipeTypes.Up;
                }
            }
            return SwipeTypes.None;
        }
    }
}