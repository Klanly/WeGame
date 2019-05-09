using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class LocalizationDBModel : DataTableDBModelBase<LocalizationDBModel, DataTableEntityBase>
    {
        /// <summary>
        /// �ļ�����
        /// </summary>
        public override string DataTableName
        {
            get
            {
                return "Localization/"+GameEntry.Localization.CurrLanguage.ToString();
            }
        }

        /// <summary>
        /// ��ǰ�����ֵ�
        /// </summary>
        public Dictionary<string, string> LocalizationDic = new Dictionary<string, string>();

        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="ms"></param>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int row = ms.ReadInt();

            int clumns = ms.ReadInt();

            for (int i = 0; i < row; i++)
            {
                LocalizationDic[ms.ReadUTF8String()] = ms.ReadUTF8String();
            }
        }
    }
}
