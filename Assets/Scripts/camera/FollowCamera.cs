using UnityEngine;
using UnityEngine.Serialization;

namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        [FormerlySerializedAs("FollowSpeed")] public float followSpeed = 32f; // Increase this value to make the camera follow faster
        public float yOffset =0f;
        public Transform target;

        // Update is called once per frame
        void Update()
        {
            if (enter.isAnimationFinished)
            {
                Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
                transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
            }
        }
    }
}