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

    /// <summary>
    /// ダイアログクラス
    /// </summary>
    public abstract class Dialog : UIObject, IDialog
    {
        /// <summary>
        /// 閉じられた
        /// </summary>
        public IObservable<Unit> OnClose => onCloseSubject;

        /// <summary>
        /// 閉じられた時のSubject
        /// </summary>
        private Subject<Unit> onCloseSubject = new Subject<Unit>();

        void OnDestroy()
        {
            onCloseSubject.OnNext(Unit.Default);
        }
    }
}
