using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UIFromBase : MonoBehaviour
    {
        /// <summary>
        /// ������
        /// </summary>
        public int UIFromId
        {
            get;
            private set;
        }

        /// <summary>
        /// ������
        /// </summary>
        public byte UIGroupId
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ǰ�Ļ���
        /// </summary>
        public Canvas CurrCanvas
        {
            get;
            private set;
        }

        /// <summary>
        /// �ر�ʱ��
        /// </summary>
        public float CloseTime
        {
            get;
            private set;
        }

        /// <summary>
        /// ���ò����
        /// </summary>
        public bool DisabledUILayer
        {
            get;
            private set;
        }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsLock
        {
            get;
            private set;
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        private void Awake()
        {
            CurrCanvas = GetComponent<Canvas>();

        }
        private void Start()
        {
            OnInit(UserData);
            Open(UserData,true);
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="uiFromId"></param>
        /// <param name="groupId"></param>
        /// <param name="disabledUILayer"></param>
        /// <param name="isLock"></param>
        /// <param name="userData"></param>
        internal void Init(int uiFromId,byte groupId,bool disabledUILayer,bool isLock,object userData)
        {
            UIFromId = uiFromId;
            UIGroupId = groupId;
            DisabledUILayer = disabledUILayer;
            IsLock = isLock;
            UserData = userData;
           
        }

        internal void Open(object userData,bool isFromInit=false)
        {
            if (!isFromInit)
            {
                UserData = userData;
            }
           

            if (!DisabledUILayer)
            {
                //�㼶���� ���Ӳ㼶
                GameEntry.UI.SetSortOrder(this,true);
            }
            OnOpen(UserData);
        }

        public void Close()
        {
            GameEntry.UI.CloseUIFrom(this);
        }

        public void ToClose()
        {
            if (!DisabledUILayer)
            {
                //�㼶���� ���ٲ㼶
                GameEntry.UI.SetSortOrder(this, false);
            }
            OnClose();

            CloseTime = Time.time;
            GameEntry.UI.Enqueue(this);
        }

        private void OnDestroy()
        {
            OnBeforeDestroy();
        }


        protected virtual void OnInit(object userData) { }
        protected virtual void OnOpen(object userData) { }
        protected virtual void OnClose() { }
        protected virtual void OnBeforeDestroy() { }
    }
}
