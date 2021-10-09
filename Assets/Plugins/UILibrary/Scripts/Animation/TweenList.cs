using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UILibrary.Animation
{
    /// <summary>
    /// Tweenリスト
    /// </summary>
    [AddComponentMenu("UILibrary/Animation/TweenList")]
    public class TweenList : MonoBehaviour
    {
        /// <summary>
        /// Tweenリスト
        /// </summary>
        [SerializeField]
        private List<AnimationTween> Tweens = new List<AnimationTween>();

        /// <summary>
        /// 終了Action
        /// </summary>
        public Action OnFinish { set; private get; }

        /// <summary>
        /// 再生中？
        /// </summary>
        private bool bIsPlaying = false;

        /// <summary>
        /// 再生
        /// </summary>
        public void Play()
        {
            bIsPlaying = true;
            foreach (var tween in Tweens)
            {
                tween.Play();
            }
        }

        void Update()
        {
            if (!bIsPlaying) { return; }

            foreach (var tween in Tweens)
            {
                if (!tween.IsFinished) { return; }
            }

            // 全部終了していたらここに来る
            bIsPlaying = false;
            OnFinish?.Invoke();
        }
    }
}
