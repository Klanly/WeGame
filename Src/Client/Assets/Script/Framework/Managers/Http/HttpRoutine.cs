using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

namespace Framework
{
	public delegate void HttpSendDataCallBack(HttpCallBackArgs args);
	/// <summary>
	/// Http������
	/// </summary>
	public class HttpRoutine
	{

		#region ����
		/// <summary>
		/// HTTP����ص�
		/// </summary>
		private HttpSendDataCallBack m_CalBack;
		/// <summary>
		/// HTTP����ص�����
		/// </summary>
		private HttpCallBackArgs m_CallBackArgs;

		/// <summary>
		/// �Ƿ�æ
		/// </summary>
		public bool IsBusy
		{
			private set;
			get;
		}

		#endregion

		public HttpRoutine()
		{
			m_CallBackArgs = new HttpCallBackArgs();
		}

		#region SendData ����WEB����

		/// <summary>
		/// ����Web����
		/// </summary>
		/// <param name="url"></param>
		/// <param name="calBack"></param>
		/// <param name="isPost"></param>
		/// <param name="json"></param>
		public void SendData(string url, HttpSendDataCallBack calBack, bool isPost = false, Dictionary<string, object> dic = null)
		{
			if (IsBusy)
				return;
			IsBusy = true;

			m_CalBack = calBack;

			if (!isPost)
			{
				GetUrl(url);

			}
			else
			{

				//web����
				if (dic != null)
				{
					//�ͻ��˱�ʶ��
					dic["deviceUniqueIdentifier"] = DeviceUtil.DeviceIdentifier;
					//�ͻ��˱�ʶ��
					dic["deviceModel"] = DeviceUtil.DeviceModel;
					long t = GameEntry.Data.SystemDataManager.CurrServerTime;
					//ǩ��
					dic["sign"] = EncryptUtil.Md5(string.Format("{0}:{1}", t, DeviceUtil.DeviceIdentifier));
					//ʱ���
					dic["t"] = t;
				}

                string json = string.Empty;
                if (dic!=null)
                {
                    json = JsonMapper.ToJson(dic);
                    GameEntry.Pool.EnqueueClassObject(dic);
                }

				PostUrl(url, dic == null ? "" :JsonMapper.ToJson(dic));
			}
		}
		#endregion

		#region Get����
		private void GetUrl(string url)
		{
			UnityWebRequest data =UnityWebRequest.Get(url);
			GameEntry.Http.StartCoroutine(Request(data));
		}
		#endregion

		#region PostUrl Post����
		private void PostUrl(string url, string json)
		{
			//����һ����
			WWWForm form = new WWWForm();
			//�������ֵ
			form.AddField("", json);
			UnityWebRequest data = UnityWebRequest.Post(url, form);
			GameEntry.Http.StartCoroutine(Request(data));

		}
		private IEnumerator Request(UnityWebRequest data)
		{
			yield return data.SendWebRequest();
			IsBusy = false;

			if (data.isNetworkError || data.isHttpError)
			{
				if (m_CalBack != null)
				{
					m_CallBackArgs.HasError = true;
					m_CallBackArgs.Value = data.error;
					m_CalBack(m_CallBackArgs);
				}
			}
			else
			{
				if (m_CalBack != null)
				{
					m_CallBackArgs.HasError = false;
					m_CallBackArgs.Value = data.downloadHandler.text;

#if DEBUG_LOG_PROTO
                    Debug.Log("<color=#00eaff>������Ϣ:</color><color=#00ff9c>"+data.url+"</color>");
                    Debug.Log("<color=#c5e1dc>====>>"+JsonUtility.ToJson(m_CallBackArgs)+"</color>");
#endif
                    m_CalBack(m_CallBackArgs);
				}
			}
			data.Dispose();
			data = null;
            ///�س�
            GameEntry.Pool.EnqueueClassObject(this);
        }
		#endregion

	}
}
