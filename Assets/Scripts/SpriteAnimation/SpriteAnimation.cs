using UnityEngine;

namespace SpriteAnimation {
    [CreateAssetMenu(fileName = "Animation", menuName = "Sprite Animation")]
    public class SpriteAnimation : ScriptableObject {
        public bool Loop;
        public Frame[] Frames;

        [System.Serializable]
        public class Frame {
            public float Duration;
            public Sprite Sprite;
        }

    }
}
