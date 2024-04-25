using System.Collections;
using UnityEngine;

namespace Graphics.traps.firetrap
{
    public class fire : MonoBehaviour
    {
        public AnimationClip fireAnim;
        public AnimationClip fireDangerousAnim;
        public AnimationClip fire2Anim;
        private Animation animation;

        void Start()
        {
            animation = GetComponent<Animation>();
            animation.AddClip(fireAnim, "fire");
            animation.AddClip(fireDangerousAnim, "fireDangerous");
            animation.AddClip(fire2Anim, "fire2");
        }

    }
}