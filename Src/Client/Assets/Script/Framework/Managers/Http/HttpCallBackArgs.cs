using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// Http����Ļص�����
    /// </summary>
    public class HttpCallBackArgs : EventArgs
    {
        /// <summary>
        /// �Ƿ񱨴�
        /// </summary>
        public bool HasError;
        /// <summary>
        /// ��������
        /// </summary>
        public string Value;
    }
}
