using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UILibrary.Util
{
    /// <summary>
    /// Prefab管理
    /// ※別にUI以外でも使えるから使ってもいいよ
    /// </summary>
    public class PrefabManager
    {
        /// <summary>
        /// パスをキーにしてPrefabを格納するDictionary
        /// </summary>
        private Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();

        /// <summary>
        /// 指定したパスのPrefabをインスタンス化し、Componentを取得する
        /// </summary>
        /// <param name="path">パス</param>
        /// <typeparam name="T">Componentの型</typeparam>
        /// <returns>Component</returns>
        public T Instantiate<T>(string path)
            where T : MonoBehaviour
        {
            if (!prefabDic.ContainsKey(path))
            {
                var prefab = Resources.Load<GameObject>(path);
                Debug.Assert(prefab != null, "Prefab Load Failed. Path:{0}", prefab);
            }

            var obj = GameObject.Instantiate<GameObject>(prefabDic[path]);
            var component = obj.GetComponent<T>();
            if (component == null) { throw new Exception(string.Format("Prefab:{0} に、{1}がAttachされていません。", path, typeof(T).Name)); }

            return component;
        }

        #region Singleton
        private PrefabManager() { }
        private static PrefabManager instance = new PrefabManager();
        public static PrefabManager Instance { get { return instance; } }
        #endregion
    }
}
