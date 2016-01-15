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
    public interface IfIOStrategy//文件读写算法接口
    {
        cNet ReadFile(string sPath, StyleSet PaintStyle);
        void SaveFile(XmlDocument doc, string sPath);
    }
}
