using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UILibrary;
using UILibrary.Util;
using UniRx.Triggers;
using System;

/// <summary>
/// シーケンス
/// </summary>
public class Sequence : MonoBehaviour
{
    /// <summary>
    /// ダイアログ表示中？
    /// </summary>
    private bool bShownDialog = false;

    /// <summary>
    /// UIのルート
    /// </summary>
    [SerializeField]
    private UIRoot uiRoot = null;

    void Awake()
    {
        this.UpdateAsObservable()
            .Where(_ => !bShownDialog && Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ =>
            {
                try
                {
                    TestDialog dialog = PrefabManager.Instance.Instantiate<TestDialog>("TestDialog");
                    dialog.OnClose.Subscribe(__ => bShownDialog = false).AddTo(gameObject);
                    uiRoot.AddChild(dialog, Vector3.zero);
                    bShownDialog = true;
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }).AddTo(gameObject);
    }
}
