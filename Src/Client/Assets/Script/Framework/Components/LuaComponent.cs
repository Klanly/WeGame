using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class LuaComponent : BaseComponent
    {
        private LuaManager m_LuaManager;

        /// <summary>
        /// �Ƿ��ӡЭ����־
        /// </summary>
        public bool DebugLogProto = false;

        public override void Shutdown()
        {
            LoadDaTableMS.Dispose();
            LoadDaTableMS.Close();
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_LuaManager = new LuaManager();
#if DEBUG_LOG_PROTO
            DebugLogProto = true;
#endif
        }

        /// <summary>
        /// �������ݱ�
        /// </summary>
        public MMO_MemoryStream LoadDaTableMS
        {
            get;
            private set;
        }
        public MMO_MemoryStream LoadDataTable(string TableName)
        {

            //1.�õ����buffer
            byte[] buffer =IOUtil.GetFileBuffer(string.Format("{0}/Download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath, TableName));

            LoadDaTableMS.SetLength(0);
            LoadDaTableMS.Write(buffer,0,buffer.Length);
            LoadDaTableMS.Position = 0;

            return LoadDaTableMS;
        }

        /// <summary>
        /// ��lua�м���MMO_MemoryStream
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public MMO_MemoryStream LoadSocketReceiveMS(byte[] buffer)
        {
            MMO_MemoryStream ms = GameEntry.Socket.SocketReceiveMS;
            ms.SetLength(0);
            ms.Write(buffer,0,buffer.Length);
            ms.Position = 0;
            return ms;

        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadDaTableMS = new MMO_MemoryStream();
            m_LuaManager.Init();

        }
    }
}
