using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UILibrary
{
    /// <summary>
    /// UIオブジェクト
    /// </summary>
    public abstract class UIObject : MonoBehaviour
    {
        /// <summary>
        /// 子を追加
        /// </summary>
        /// <param name="childObject">子オブジェクト</param>
        /// <param name="position">表示する座標</param>
        /// <param name="zOrder">描画優先度</param>
        public void AddChild(UIObject childObject, Vector2 position, int zOrder = 0)
        {
            childObject.transform.parent = transform;
            childObject.transform.localPosition = new Vector3(position.x, position.y, zOrder);
        }
    }
}
