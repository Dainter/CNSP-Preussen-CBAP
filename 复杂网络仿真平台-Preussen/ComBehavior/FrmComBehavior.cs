using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using CNSP.Platform;

namespace CNSP.ComBehavior
{
    public partial class FrmComBehavior : Form
    {
        FrmMain father;
        bNet curNetwork;
        int PicWidth;         //全局变量，图像宽度
        int PicHeight;        //全局变量，图像高度
        Graphics GraCam;             //全局变量，网络图形对象
        Bitmap img;                  //全局变量，网络图像
        public StyleSet GlobalPaintStyle;  // 全局变量 绘图风格


        public FrmComBehavior(FrmMain owner)
        {
            InitializeComponent();
            //设置FrmMain为父窗体，可以读取父窗体数据
            father = owner;
            GlobalPaintStyle = father.GlobalPaintStyle;
            PicWidth = father.PicWidth;
            PicHeight = father.PicHeight;
            XmlDocument doc = father.ComplexNet.ToXML();
            curNetwork = new bNet(doc, GlobalPaintStyle);
        }

        //窗体图像重置
        public void GraphicReset()
        {
            int x, y;

            if (img != null)
            {
                img.Dispose();
            }
            img = new Bitmap(PicWidth, PicHeight);
            GraCam = Graphics.FromImage(img);
 
            GraCam.SmoothingMode = GlobalPaintStyle.SmoothMode;
            PicCam.Image = img;


            //主窗体重置
            x = MainLayout.Location.X + TabMain.Location.X + PanelPic.Location.X + PicWidth + 40;
            y = MainLayout.Location.Y + TabMain.Location.Y + PanelPic.Location.Y + PicHeight + 78;
            this.MaximumSize = new Size(x, y);
        }


        private void FrmComBehavior_Load(object sender, EventArgs e)
        {

        }

        private void PaintButton_Click(object sender, EventArgs e)
        {
            GraphicReset();
            //绘制网络结构图
            curNetwork.Draw(ref GraCam);
            
        }
    }
}
