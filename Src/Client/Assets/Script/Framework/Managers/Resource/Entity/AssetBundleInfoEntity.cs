using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// ��Դ����Ϣʵ��
    /// </summary>
    public class AssetBundleInfoEntity
    {
        /// <summary>
        /// ��Դ������
        /// </summary>
        public string AssetBundleName;
        /// <summary>
        /// MD5
        /// </summary>
        public string MD5;
        /// <summary>
        /// ��С��k��
        /// </summary>
        public int Size;
        /// <summary>
        /// �Ƿ��ʼ��Դ
        /// </summary>
        public bool IsFirstData;
        /// <summary>
        /// �Ƿ��Ѿ�����
        /// </summary>
        public bool IsEncrypt;
    }
}
