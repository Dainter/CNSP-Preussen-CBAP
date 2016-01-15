using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;
using CNSP.Platform;
using System.Xml;
using CNSP.Platform.Paint;

namespace CNSP.Platform.IO
{
    public interface IfIOStrategy//�ļ���д�㷨�ӿ�
    {
        cNet ReadFile(string sPath, StyleSet PaintStyle);
        void SaveFile(XmlDocument doc, string sPath);
    }
}
