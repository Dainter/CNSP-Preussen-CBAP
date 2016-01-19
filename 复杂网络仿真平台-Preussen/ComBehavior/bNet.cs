using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using CNSP.Platform;
using CNSP.Platform.Paint;
using CNSP.Core;

namespace CNSP.ComBehavior
{
    class bNet
    {
        public List<IfComBehavior> Network; //网络节点集合-（继承通信行为接口的节点，不仅仅是bNode）
        public int intNumber;           //节点总数
        public int intEdge;               //连边总数
        public string strType;
        public IfPaintStrategy NetPainter;              //网络绘制算法对象
        //属性
        public int Number
        {
            get
            {
                return this.intNumber;
            }
        }
        public int Edge
        {
            get
            {
                return this.intEdge;
            }
        }
        public string Type
        {
            get
            {
                return strType;
            }
        }
        //方法
        //将xml文件转化为网络
        public bNet(XmlDocument doc, StyleSet PaintStyle)
        {
            XmlNodeList Nodelist;
            XmlNode xmlroot;
            IfComBehavior newNode;

            this.Network = new List<IfComBehavior>();
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表

            this.intNumber = 0;
            foreach (XmlElement curNode in Nodelist)                                      //遍历节点列表
            {
                newNode = new bNode(intNumber);
                newNode.XMLinput(curNode, 0);
                this.Network.Add(newNode);                          //调用下层函数，生成新节点
                this.intNumber++;
            }
            Initialized(PaintStyle);
        }
        
        //网络初始化，在加入所有节点之后执行一次
        public void Initialized(StyleSet PaintStyle)
        {
            NetworkType();//网络类型分析
            DegreeStat();//节点度统计
            if (PaintStyle != null)
            {
                NetPainter = new DefaultStrategy(PaintStyle);
            }
            NetPainter.UpdateLocation(this.ToXML());//节点坐标刷新
            NetPainter.UpdateImage();//节点图像刷新
        }
        
        //网络类型分析函数，确定网络是否有向
        private void NetworkType()
        {
            int i, intTarget, intSource;
            for (i = 0; i < intNumber; i++)
            {
                foreach (Edge edge in Network[i])
                {
                    intTarget = edge.Target;
                    intSource = i;
                    if (Network[intTarget].Contains(intSource) == false)
                    {
                        strType = "有向图";
                        return;
                    }
                }
            }
            strType = "无向图";
            return;
        }

        //节点度统计函数，最大度，最小度，度列表
        private void DegreeStat()
        {
            int intTotal;

            intTotal = 0;
            //找出最大和最小度
            foreach(IfComBehavior curNode in Network)
            {
                intTotal += curNode.Degree;
            }
            if (strType == "有向图")
            {
                intEdge = intTotal;
            }
            else
            {
                intEdge = intTotal / 2;
            }
        }

        //绘制网络结构图，输入目标图元，和高亮节点编号（默认为没有）
        public void Draw(ref Graphics GraCam, int intExclude = -1)//
        {
            NetPainter.Draw(ref GraCam, -1);
        }

        //将网络结构转化为XML文件
        public XmlDocument ToXML()
        {
            XmlDocument doc = new XmlDocument();
            //所有网络数据都保存为xml格式
            XmlElement root = doc.CreateElement("Network");
            root.SetAttribute("Nodes", intNumber.ToString());
            root.SetAttribute("Edges", intEdge.ToString());

            foreach (IfComBehavior xNode in Network)
            {
                root.AppendChild(xNode.XMLoutput(ref doc));     //循环调用底层节点的输出函数
            }
            doc.AppendChild(root);
            return doc;
        }

    }
}
