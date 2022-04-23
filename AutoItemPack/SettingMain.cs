using AutoItemPack.Common;

using Common;
using Common.Register;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoItemPack
{
    public partial class SettingMain : Form
    {
        public SettingMain()
        {
            InitializeComponent();
            LoadReg();
        }

       

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveText();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExport_Click(object sender, EventArgs e)
        {
            string cmdStr = $@"reg export ""HKCU\{RegistryStorageKeys.RegPath}""  ""{PathHelpStatus.Path}\reg.reg"" /y ";
            CmdHelper.ExeCommand(cmdStr);
            SaveLog("导出成功，请注意当前目录下生成的Reg文件。");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInIt_Click(object sender, EventArgs e)
        {
            LoadReg();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpty_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }


        private void SaveText() 
        {
            try
            {
                LoadCtrlName(this,1);
                SaveLog("数据保存成功。");
            }
            catch (Exception ex)
            {
                SaveLog($"数据保存异常：{ex.ToString()}");
            }
            
        }

        private void LoadReg()
        {
            SaveLog($"数据开始加载");
            try
            {
                LoadCtrlName(this,0);
                SaveLog($"数据加载完毕");
            }
            catch (Exception ex)
            {
                SaveLog($"数据加载异常:{ex.ToString()}");
            }

        }

        void LoadCtrlName(Control parent,int code)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Name.Contains("txt") || ctrl.Name.Contains("comIs"))
                {
                    if (code == 0) 
                    {
                        RegistryStorageHelper.SetValueToReg(ctrl.Tag.ToString(), ctrl.Text);
                    }
                    if (code == 1) 
                    {
                        ctrl.Text = RegistryStorageHelper.GetValueFromReg<string>(ctrl.Tag.ToString());
                    }
                    textLog.Text += $"\r\n {ctrl.Tag}:{ctrl.Text}";
                }
                if (ctrl.Controls.Count > 0)
                {
                    LoadCtrlName(ctrl,code);
                }
            }
        }

        void SaveLog(string OutTextlog) 
        {
            textLog.Text += $" \r\n {OutTextlog}";
        }

       

    }
}
