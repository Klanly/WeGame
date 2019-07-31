using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// StreamingAssets������
    /// </summary>
    public class StreamingAssetsManager 
    {
        /// <summary>
        /// StreamingAssets��Դ·��
        /// </summary>
        private string m_StreamingAssetsPath;
        
        public StreamingAssetsManager()
        {
            m_StreamingAssetsPath = "file:///" + Application.streamingAssetsPath;

#if UNITY_ANDROID && !UNITY_EDITOR
            m_StreamingAssetsPath=Application.streamingAssetsPath;
#endif
        }

        /// <summary>
        /// ��ȡStreamAssets�µ���Դ
        /// </summary>
        /// <param name="url"></param>
        /// <param name="onCompelete"></param>
        /// <returns></returns>
        public IEnumerator ReadStreamingAsset(string url,Action<byte[]>onCompelete)
        {
            using (WWW www=new WWW(url))
            {
                yield return www;

                if (www.error==null)
                {
                    if (onCompelete!=null)
                    {
                        onCompelete(www.bytes);

                    }
                }
                else
                {
                    Debug.LogError(www.error);
                }

            }
        }

        /// <summary>
        /// ��ȡֻ������Դ��
        /// </summary>
        public void ReadAssetBundle(string fileUrl, Action<byte[]> onCompelete)
        {
            GameEntry.Resource.StartCoroutine(ReadStreamingAsset(string.Format("{0}/AssetBundle/{1}",m_StreamingAssetsPath,fileUrl), onCompelete));
        }
    }
}
