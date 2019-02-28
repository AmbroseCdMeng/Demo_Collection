using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqOperSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义公共变量及Linq连接对象
        //定义数据库连接字符串
        string strCon = "Data Source=(local);Database=db_09;Uid=sa;Pwd=;";
        linqtosqlDataContext linq;          //声明Linq连接对象
        #endregion

        //窗体加载时，显示所有员工信息
        private void Form1_Load(object sender, EventArgs e)
        {
            BindInfo();
        }

        //添加员工信息
        private void btnAdd_Click(object sender, EventArgs e)
        {
            linq = new linqtosqlDataContext(strCon);    //实例化Linq连接对象
            tb_Employee employee = new tb_Employee();   //实例化tb_Employee类对象
            //为tb_Employee类中的员工实体赋值
            employee.ID = txtID.Text;
            employee.Name = txtName.Text;
            employee.Sex = cboxSex.Text;
            employee.Age = Convert.ToInt32(txtAge.Text);
            employee.Tel = txtTel.Text;
            employee.Address = txtAddress.Text;
            employee.QQ = Convert.ToInt32(txtQQ.Text);
            employee.Email = txtEmail.Text;
            linq.tb_Employee.InsertOnSubmit(employee);  //添加员工信息
            linq.SubmitChanges();                       //提交操作
            BindInfo();
        }

        //修改员工信息
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("请选择要修改的记录");
                return;
            }
            linq = new linqtosqlDataContext(strCon);    //实例化Linq连接对象
            //查找要修改的员工信息
            var result = from employee in linq.tb_Employee
                         where employee.ID == txtID.Text
                         select employee;
            //对指定的员工信息进行修改
            foreach (tb_Employee tbemployee in result)
            {
                tbemployee.Name = txtName.Text;
                tbemployee.Sex = cboxSex.Text;
                tbemployee.Age = Convert.ToInt32(txtAge.Text);
                tbemployee.Tel = txtTel.Text;
                tbemployee.Address = txtAddress.Text;
                tbemployee.QQ = Convert.ToInt32(txtQQ.Text);
                tbemployee.Email = txtEmail.Text;
                linq.SubmitChanges();
            }
            MessageBox.Show("员工信息修改成功");
            BindInfo();
        }

        //删除员工信息
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("请选择要删除的记录");
                return;
            }
            linq = new linqtosqlDataContext(strCon);    //实例化Linq连接对象
            //查找要删除的员工信息
            var result = from employee in linq.tb_Employee
                         where employee.ID == txtID.Text
                         select employee;
            linq.tb_Employee.DeleteAllOnSubmit(result); //删除员工信息
            linq.SubmitChanges();                       //实例化Linq连接对象提交操作
            MessageBox.Show("员工信息删除成功");
            BindInfo();
        }

        //查询员工信息
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindInfo();
        }

        //显示选中单元格中的员工信息
        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linq = new linqtosqlDataContext(strCon);    //实例化Linq连接对象
            //获取选中的员工编号
            txtID.Text=Convert.ToString(dgvInfo[0, e.RowIndex].Value).Trim();
            //根据选中的员工编号获取其详细信息，并重新成成一个表
            var result = from info in linq.tb_Employee
                         where info.ID == txtID.Text
                         select new
                         {
                             ID = info.ID,
                             Name = info.Name,
                             Sex = info.Sex,
                             Age = info.Age,
                             Tel = info.Tel,
                             Address = info.Address,
                             QQ = info.QQ,
                             Email = info.Email
                         };
            //相应的文本框及下拉列表中显示选中员工的详细信息
            foreach (var item in result)
            {
                txtName.Text = item.Name;
                cboxSex.Text = item.Sex;
                txtAge.Text = item.Age.ToString();
                txtTel.Text = item.Tel;
                txtAddress.Text = item.Address;
                txtQQ.Text = item.QQ.ToString();
                txtEmail.Text = item.Email;
            }
        }

        #region 查询员工信息
        /// <summary>
        /// 查询员工信息
        /// </summary>
        private void BindInfo()
        {
            linq = new linqtosqlDataContext(strCon);    //实例化Linq连接对象
            if (txtKeyWord.Text == "")
            {
                //获取所有员工信息
                var result = from info in linq.tb_Employee
                             select new
                             {
                                 员工编号 = info.ID,
                                 员工姓名 = info.Name,
                                 性别 = info.Sex,
                                 年龄 = info.Age,
                                 电话 = info.Tel,
                                 地址 = info.Address,
                                 QQ = info.QQ,
                                 Email = info.Email
                             };
                dgvInfo.DataSource = result;            //对DataGridView控件进行数据绑定
            }
            else
            {
                switch (cboxCondition.Text)
                {
                    case "员工编号":
                        //根据员工编号查询员工信息
                        var resultid = from info in linq.tb_Employee
                                       where info.ID == txtKeyWord.Text
                                       select new
                                       {
                                           员工编号 = info.ID,
                                           员工姓名 = info.Name,
                                           性别 = info.Sex,
                                           年龄 = info.Age,
                                           电话 = info.Tel,
                                           地址 = info.Address,
                                           QQ = info.QQ,
                                           Email = info.Email
                                       };
                        dgvInfo.DataSource = resultid;
                        break;
                    case "员工姓名":
                        //根据员工姓名查询员工信息
                        var resultname = from info in linq.tb_Employee
                                         where info.Name.Contains(txtKeyWord.Text)
                                         select new
                                         {
                                             员工编号 = info.ID,
                                             员工姓名 = info.Name,
                                             性别 = info.Sex,
                                             年龄 = info.Age,
                                             电话 = info.Tel,
                                             地址 = info.Address,
                                             QQ = info.QQ,
                                             Email = info.Email
                                         };
                        dgvInfo.DataSource = resultname;
                        break;
                    case "性别":
                        //根据员工性别查询员工信息
                        var resultsex = from info in linq.tb_Employee
                                        where info.Sex == txtKeyWord.Text
                                        select new
                                        {
                                            员工编号 = info.ID,
                                            员工姓名 = info.Name,
                                            性别 = info.Sex,
                                            年龄 = info.Age,
                                            电话 = info.Tel,
                                            地址 = info.Address,
                                            QQ = info.QQ,
                                            Email = info.Email
                                        };
                        dgvInfo.DataSource = resultsex;
                        break;
                }
            }
        }
        #endregion
    }
}
