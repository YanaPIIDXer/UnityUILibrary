using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UILibrary;
using System;

namespace UILibrary.Animation
{
    /// <summary>
    /// アニメーションTween
    /// </summary>
    public abstract class AnimationTween : MonoBehaviour
    {
        /// <summary>
        /// アニメーション対象オブジェクト
        /// </summary>
        [SerializeField]
        private UIObject _TargetObject = null;
        protected UIObject TargetObject { get { return _TargetObject; } }

        /// <summary>
        /// アニメーションの時間
        /// </summary>
        [SerializeField]
        private float AnimationTime = 1.0f;

        /// <summary>
        /// 経過時間
        /// </summary>
        private float elapsedTime = 0.0f;

        /// <summary>
        /// 再生中か？
        /// </summary>
        private bool bIsPlaying = false;

        /// <summary>
        /// 終了しているか？
        /// </summary>
        public bool IsFinished { get { return elapsedTime >= AnimationTime; } }

        /// <summary>
        /// 再生
        /// </summary>
        public void Play()
        {
            if (TargetObject == null) { throw new Exception(string.Format("{0}:TargetObjectが設定されていません", GetType().Name)); }

            bIsPlaying = true;
            elapsedTime = 0.0f;
        }

        void Update()
        {
            if (!bIsPlaying) { return; }

            if (IsFinished)
            {
                OnUpdate(1.0f);
                bIsPlaying = false;
                return;
            }

            float rate = elapsedTime / AnimationTime;
            OnUpdate(rate);

            elapsedTime += Time.deltaTime;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rate">再生時間を0.0f ~ 1.0の間で表した値</param>
        protected abstract void OnUpdate(float rate);
    }
}
