using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// </summary>
    [AddComponentMenu("UILibrary/UIRoot")]
    public class UIRoot : UIObject, IUIRoot
    {
    }
}
