using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UILibrary.Animation
{
    /// <summary>
    /// 拡縮アニメーション
    /// </summary>
    [AddComponentMenu("UILibrary/Animation/Tween Scale")]
    public class AnimationTweenScale : AnimationTween
    {
        /// <summary>
        /// 初期スケール
        /// </summary>
        [SerializeField]
        private Vector2 InitialScale = Vector2.zero;

        [SerializeField]
        private Vector2 TargetScale = Vector2.one;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rate">再生位置</param>
        protected override void OnUpdate(float rate)
        {
            Vector2 current = Vector2.Lerp(InitialScale, TargetScale, rate);
            transform.localScale = new Vector3(current.x, current.y, 1.0f);
        }
    }
}
