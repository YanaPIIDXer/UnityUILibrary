using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace UILibrary
{
    /// <summary>
    /// ダイアログインタフェース
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// 閉じられた
        /// </summary>
        IObservable<Unit> OnClose { get; }
    }
}
