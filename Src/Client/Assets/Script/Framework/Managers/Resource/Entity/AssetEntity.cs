using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// ��Դʵ��
    /// </summary>
    public class AssetEntity
    {
        /// <summary>
        /// ��Դ����
        /// </summary>
        public AssetCategory Category;
        /// <summary>
        /// ��Դʵ��
        /// </summary>
        public string AssetName;
        /// <summary>
        /// ��Դ��������
        /// </summary>
        public string AssetFullName;

        /// <summary>
        /// ������Դ���������Դ���Ǹ���Դ���
        /// </summary>
        public string AssetBundleName;
        /// <summary>
        /// ������Դ
        /// </summary>
        public List<AssetDependsEntity> DependsAssetList;

    }
}
