using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UILibrary
{
    /// <summary>
    /// UI描画のルートオブジェクトインタフェース
    /// </summary>
    public interface IUIRoot
    {
        /// <summary>
        /// 子を追加
        /// </summary>
        /// <param name="childObject">子オブジェクト</param>
        /// <param name="position">表示する座標</param>
        /// <param name="zOrder">描画優先度</param>
        void AddChild(UIObject childObject, Vector2 position, int zOrder = 0);
    }

    /// <summary>
    /// UI描画のルートオブジェクト
    /// Canvasと同じオブジェクトにAttachする
    /// </summary>
    [AddComponentMenu("UILibrary/UIRoot")]
    [RequireComponent(typeof(Canvas))]
    public class UIRoot : UIObject, IUIRoot
    {
    }
}
