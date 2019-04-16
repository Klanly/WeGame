﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 事件组件
    /// </summary>
    public class EventComponent : BaseComponent
    {
        /// <summary>
        /// 事件管理器
        /// </summary>
        private EventManager m_EventManager;

        public SocketEvent SocketEvent;

        public CommonEvent CommonEvent;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_EventManager = new EventManager();
            SocketEvent = m_EventManager.SocketEvent;
            CommonEvent = m_EventManager.CommonEvent;
        }
        public override void Shutdown()
        {
            m_EventManager.Dispose();
        }
    }
}
