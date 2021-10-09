using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UILibrary;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 実験用ダイアログ
/// </summary>
public class TestDialog : Dialog
{
    /// <summary>
    /// 閉じるボタン
    /// </summary>
    [SerializeField]
    private Button closeButton = null;

    void Awake()
    {
        closeButton.OnClickAsObservable()
                   .Subscribe(_ => Close())
                   .AddTo(gameObject);
    }
}
