using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CNSP.Platform;
using CNSP.Core;

namespace CNSP.ComBehavior
{
    public class bNode : IfComBehavior
    {
        //成员变量
        public Node node;            //节点成员
        int intCom;
        //属性
        int IfComBehavior.Number
        {
            get
            {
                return this.node.Number;
            }
        }
        int IfComBehavior.Degree
        {
            get
            {
                return this.node.Degree;
            }
        }
        Point IfComBehavior.Location
        {
            get
            {
                return this.node.Location;
            }
            set
            {
                this.node.Location = value;
            }
        }
        int IfComBehavior.ComCount
        {
            get
            {
                return intCom;
            }
            set
            {
                intCom = value;
            }
        }
        //方法///////////////////////////////
        public bNode(int iNum)    //构造函数：新建
        {
            this.node = new Node(iNum);
        }

        //增加连边
        bool IfComBehavior.AddEdge(int iTarget, int iValue)
        {
            return this.node.AddEdge(iTarget, iValue);
        }

        //去除连边
        bool IfComBehavior.DecEdge(int iTarget)
        {
            return this.node.DecEdge(iTarget);
        }

        //获取指定连边权重
        int IfComBehavior.GetWeight(int iTarget)
        {
            if (node.ContainsEdge(iTarget) == true)
            {
                return node.Links[iTarget].Value;
            }
            return 0;
        }

        //检查是否包含对某个节点的连边
        bool IfComBehavior.Contains(int iTarget)
        {
            return this.node.ContainsEdge(iTarget);
        }

        //枚举器foreach语句使用
        NodeEnumerator IfComBehavior.GetEnumerator()
        {
            return this.node.GetEnumerator();
        }

        //从xml数据中生成节点
        void IfComBehavior.XMLinput(XmlElement xNode, int intNumOffset)
        {
            XmlNode degree_xml, x_xml, y_xml, com_xml, edges_xml;
            Node newNode;
            int intNum, x, y, tar, value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value) - intNumOffset;
            newNode = new Node(intNum);                                            //新建节点
            degree_xml = x_xml = y_xml = com_xml = edges_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //节点位置设置
            {
                if (curNode.Name == "Degree")//节点度
                {
                    degree_xml = curNode;
                }
                if (curNode.Name == "Xpos")//节点位置
                {
                    x_xml = curNode;
                }
                if (curNode.Name == "Ypos")
                {
                    y_xml = curNode;
                }
                if (curNode.Name == "ComCount")
                {
                    com_xml = curNode;
                }
                if (curNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = curNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null || com_xml == null)
            {
                return;
            }
            x = Convert.ToInt32(x_xml.InnerText);
            y = Convert.ToInt32(y_xml.InnerText);
            newNode.Location = new Point(x, y);
            this.intCom = Convert.ToInt32(com_xml.InnerText);

            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value) - intNumOffset;//读出目标节点
                value = Convert.ToInt32(edge.InnerText);                           //读出连边权重
                newNode.AddEdge(tar, value);                                        //加入连边
            }
            this.node = newNode;
        }

        //将节点数据保存为xml格式
        XmlElement IfComBehavior.XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement degree_xml, x_xml, y_xml, com_xml, edges_xml;
            XmlText deg_txt, x_txt, y_txt, com_txt;

            curNode.SetAttribute("num", (this.node.Number).ToString());                   //创建各属性的Tag元素
            //节点度
            degree_xml = doc.CreateElement("Degree");
            //节点位置
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");
            com_xml = doc.CreateElement("ComCount");
            //节点连边
            edges_xml = doc.CreateElement("Edges");

            deg_txt = doc.CreateTextNode(this.node.Degree.ToString());               //创建各属性的文本元素
            x_txt = doc.CreateTextNode(this.node.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.node.Location.Y.ToString());
            com_txt = doc.CreateTextNode(this.intCom.ToString());

            degree_xml.AppendChild(deg_txt);                                    //将标题元素赋予文本内容
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);
            com_xml.AppendChild(com_txt);

            curNode.AppendChild(degree_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);
            curNode.AppendChild(com_xml);
            foreach (Edge edge in this.node)                    //遍历，加入连边节点
            {
                edges_xml.AppendChild(edge.XMLItem(ref doc));
            }
            curNode.AppendChild(edges_xml);
            return curNode;
        }
    }
}
