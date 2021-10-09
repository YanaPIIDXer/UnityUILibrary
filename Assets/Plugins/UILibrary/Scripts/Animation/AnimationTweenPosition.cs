using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UILibrary.Animation
{
    /// <summary>
    /// 座標移動アニメーション
    /// </summary>
    [AddComponentMenu("UILibrary/Animation/Tween Position")]
    public class AnimationTweenPosition : AnimationTween
    {
        /// <summary>
        /// 初期座標
        /// </summary>
        [SerializeField]
        private Vector2 initialPosition = Vector2.zero;

        /// <summary>
        /// 終了座標
        /// </summary>
        [SerializeField]
        private Vector2 TargetPosition = Vector2.zero;

        /// <summary>
        /// モード
        /// </summary>
        enum EMode
        {
            World,
            Local,
        }

        /// <summary>
        /// モード
        /// </summary>
        [SerializeField]
        private EMode Mode = EMode.Local;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rate">再生位置</param>
        protected override void OnUpdate(float rate)
        {
            Vector2 current = Vector2.Lerp(initialPosition, TargetPosition, rate);
            if (Mode == EMode.World)
            {
                TargetObject.transform.position = new Vector3(current.x, current.y, transform.position.z);
            }
            else
            {
                TargetObject.transform.localPosition = new Vector3(current.x, current.y, transform.localPosition.z);
            }
        }
    }
}
