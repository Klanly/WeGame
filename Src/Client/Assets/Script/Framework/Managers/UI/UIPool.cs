using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UIPool
    {
        /// <summary>
        /// ������е��б�
        /// </summary>
        private LinkedList<UIFormBase> m_UIFromList;

        public UIPool()
        {
            m_UIFromList = new LinkedList<UIFormBase>();
        }

        /// <summary>
        /// ������л�ȡ����
        /// </summary>
        /// <param name="uiFromId"></param>
        /// <returns></returns>
        internal UIFormBase Dequeue(int uiFromId)
        {
            for (LinkedListNode<UIFormBase>curr= m_UIFromList.First; curr!=null; curr=curr.Next)
            {
                if (curr.Value.UIFormId==uiFromId)
                {
                    m_UIFromList.Remove(curr.Value);
                    return curr.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// �س�
        /// </summary>
        /// <param name="uIFrom"></param>
        internal void Enqueue(UIFormBase uIFrom)
        {
            uIFrom.gameObject.SetActive(false);
            m_UIFromList.AddLast(uIFrom);
        }

        /// <summary>
        /// ����ͷ�
        /// </summary>
        internal void CheckClear()
        {
            for (LinkedListNode<UIFormBase> curr = m_UIFromList.First; curr != null;)
            {
                if (!curr.Value.IsLock&&Time.time>(curr.Value.CloseTime+GameEntry.UI.UIExpire))
                {
                    Object.Destroy(curr.Value.gameObject);

                    LinkedListNode<UIFormBase> next = curr.Next;
                    m_UIFromList.Remove(curr);
                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }

        internal void CheackOpenUI()
        {
            if (m_UIFromList.Count<=GameEntry.UI.UIPoolMaxCount)
            {
                return;
            }

            for (LinkedListNode<UIFormBase> curr = m_UIFromList.First; curr != null;)
            {
                if (m_UIFromList.Count <= GameEntry.UI.UIPoolMaxCount)
                {
                    break;
                }

                if (!curr.Value.IsLock)
                {
                    Object.Destroy(curr.Value.gameObject);

                    LinkedListNode<UIFormBase> next = curr.Next;
                    m_UIFromList.Remove(curr);
                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }
    }
}
