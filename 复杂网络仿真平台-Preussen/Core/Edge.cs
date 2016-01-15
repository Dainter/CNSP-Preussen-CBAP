using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.Core
{
    public class Edge//�������������ࣺ����洢����������Ϣ
    {
        private int intSource;//�������
        private int intValue;//����Ȩ��
        private int intTarget;//�����յ�
        //����//////////////////////////
        public int Source
        {
            get
            {
                return intSource;
            }
            set
            {
                intSource =value; 
            }
        }
        public int Value
        {
            get
            {
                return intValue;
            }
            set
            {
                intValue = value;
            }
        }
        public int Target
        {
            get
            {
                return intTarget;
            }
            set
            {
                intTarget = value;
            }
        }
        //����/////////////////////////
        /*
         * Function: Edge
         * Description:��������������Edge���캯��
         * Parameters:
         *      int iSource ������ʼ�ڵ���
         *      int iTarget ������ֹ�ڵ���
         *      int iValue ����Ȩ��
         * Return Value:Edge
         */
        public Edge(int iSource , int iTarget, int iValue)//���캯�� �������������и�ֵ
        {
            this.intSource = iSource;
            this.intTarget = iTarget;
            this.intValue = iValue;
        }
        /*
         * Function: XMLItem
         * Description:XML���߽ڵ��������ɺ���
         * Parameters:
         *      XmlDocument doc ��д��XML�ĵ�����
         * Return Value: XmlElement
         */
        public XmlElement XMLItem(ref XmlDocument doc)
        {
            XmlElement curEdge = doc.CreateElement("Edge");         //��������Ԫ��
            XmlText Valuetxt;

            curEdge.SetAttribute("Target", (intTarget).ToString());   //��������Ԫ�أ�ֵΪĿ��ڵ�
            Valuetxt = doc.CreateTextNode(intValue.ToString());     //�����ı�Ԫ�أ�ֵΪ����Ȩ��
            curEdge.AppendChild(Valuetxt);                                  //���Ժ��ı�Ԫ�ؼ��뵱ǰ����Ԫ��

            return curEdge;
        }
    }
}
