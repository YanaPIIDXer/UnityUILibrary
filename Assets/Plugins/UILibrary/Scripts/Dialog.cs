using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UILibrary.Animation;

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

        /// <summary>
        /// 閉じる
        /// </summary>
        void Close();
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

        /// <summary>
        /// 開くアニメーション
        /// </summary>
        [SerializeField]
        private TweenList OpenTweens = null;

        /// <summary>
        /// 閉じるアニメーション
        /// </summary>
        [SerializeField]
        private TweenList CloseTweens = null;

        void Start()
        {
            if (OpenTweens != null)
            {
                OpenTweens.Play();
            }
        }

        void OnDestroy()
        {
            onCloseSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        public void Close()
        {
            if (CloseTweens == null)
            {
                Destroy(gameObject);
                return;
            }

            CloseTweens.OnFinish = () => Destroy(gameObject);
            CloseTweens.Play();
        }
    }
}
