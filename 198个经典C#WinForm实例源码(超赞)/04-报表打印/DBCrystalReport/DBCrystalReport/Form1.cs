using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace DBCrystalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //显示所有学生信息
        private void Form1_Load(object sender, EventArgs e)
        {
            string P_str_sql = " {tb_Student.ID} like '*'";
            crystalReportViewer1.ReportSource = CrystalReports("CrystalReport1.rpt", P_str_sql);
        }

        //按学生编号查询学生信息
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                string P_str_sql = " {tb_Student.ID} like '" + toolStripTextBox1.Text.Trim() + "'";
                crystalReportViewer1.ReportSource = CrystalReports("CrystalReport1.rpt", P_str_sql);
            }
            else
                Form1_Load(sender, e);
        }

        //按回车键查询学生信息
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }

        //退出当前应用程序
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region  绑定水晶报表
        /// <summary>
        /// 绑定水晶报表
        /// </summary>
        /// <param name="P_str_creportName">报表名称</param>
        /// <param name="P_str_sql">SQL语句</param>
        /// <returns>返回ReportDocument对象</returns>
        public ReportDocument CrystalReports(string P_str_creportName, string P_str_sql)
        {
            ReportDocument reportDocument = new ReportDocument();
            string P_str_creportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            P_str_creportPath += "\\" + P_str_creportName;
            reportDocument.Load(P_str_creportPath);
            reportDocument.DataDefinition.RecordSelectionFormula = P_str_sql;
            return reportDocument;
        }
        #endregion
    }
}