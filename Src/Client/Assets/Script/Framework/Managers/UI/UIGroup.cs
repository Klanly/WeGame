using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// UI����
    /// </summary>
    [System.Serializable]
    public class UIGroup
    {
        /// <summary>
        /// ������
        /// </summary>
        public byte Id;

        /// <summary>
        /// ��������
        /// </summary>
        public ushort BaseOrder;

        public Transform Group;
    }
}
