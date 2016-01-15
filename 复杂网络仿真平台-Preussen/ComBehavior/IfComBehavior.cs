using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CNSP.Core;

namespace CNSP.ComBehavior
{
    public interface IfComBehavior//通信行为节点接口
    {
        //属性-通信行为节点专用属性
        int Number { get; }
        int Degree { get; }
        Point Location { get; set; }
        //方法-通信行为仿真专用函数
        bool AddEdge(int iTarget, int iValue);
        bool DecEdge(int iTarget);
        int GetWeight(int iTarget);
        bool Contains(int iTarget);
        NodeEnumerator GetEnumerator();
        XmlElement XMLoutput(ref XmlDocument doc);
        void XMLinput(XmlElement xNode, int intNumOffset); //intNumOffset用于区分版本，如果等于0则代表新版本，编号从0开始，如果为1，代表老版本，编号从1开始。

    }
}
