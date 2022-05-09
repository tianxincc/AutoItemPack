using AutoItemPack.Common;

using Common;
using Common.Register;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoItemPack
{
    public partial class SettingMain : Form
    {

        private static List<FTPFileUoload> fTPFileUoloads = new List<FTPFileUoload>();

        public SettingMain()
        {
            InitializeComponent();
            LoadReg();
            LoadStart();
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
            try
            {
                LoadReg();
                if (SQLHelper.IsTable())
                {
                    SaveLog($"缺少重要数据文件，正在创建...");
                    SQLHelper.CreateFileTable();
                }
                SaveLog($"初始化成功。");
            }
            catch (Exception ex)
            {
                SaveLog($"初始化数据异常{ex}");
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            SQLHelper.BtnDeleteFile();
            SaveLog("当前SQL链接远程文件已清空");
            FtpHelper.GetEmptyFiles();
            SaveLog("FTP链接远程文件已清空");
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (GetRegValue(RegistryStorageKeys.StationFTPKey).Equals(RegistryStorageKeys.KeyY)) 
            {

                GetFileSave(new DirectoryInfo(PathHelpStatus.Path), GetRegValue(RegistryStorageKeys.StationFTPKey));
                ObjectToJson("FilePath", fTPFileUoloads);
                SaveLog("已保存文件到FTP远端");
            }

            if (GetRegValue(RegistryStorageKeys.StationSQLKey).Equals(RegistryStorageKeys.KeyY))
            {
                SQLHelper.BtnDeleteFile();
                GetFileSave(new DirectoryInfo(PathHelpStatus.Path), GetRegValue(RegistryStorageKeys.StationSQLKey));
                SaveLog("已保存文件到SQL远端");
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (GetRegValue(RegistryStorageKeys.StationFTPKey).Equals(RegistryStorageKeys.KeyY))
            {
                SQLHelper.BtnUpdateFileToFTP();
            }

            if (GetRegValue(RegistryStorageKeys.StationSQLKey).Equals(RegistryStorageKeys.KeyY))
            {
                if (SQLHelper.BtnIsDownload()) 
                {
                    SQLHelper.BtnUpdateFileToSQL();
                    RegistryStorageHelper.SetValueToReg("GUID", SQLHelper.guidstr);
                    SaveLog("SQL更新文件成功");
                }
            }
        }


        private void SaveText() 
        {
            try
            {
                LoadCtrlName(this, PathHelpStatus.saveStatus);
                JoinPath();
                SaveLog("数据保存成功。");
            }
            catch (Exception ex)
            {
                SaveLog($"数据保存异常：{ex}");
            }
            
        }

        private void LoadReg()
        {
            SaveLog($"基本数据开始加载");
            try
            {
                txtGUID.Text = PathHelpStatus.guid;
                LoadCtrlName(this, PathHelpStatus.loadStatus);
                JoinPath();
                SaveLog($"基本数据加载完毕");
            }
            catch (Exception ex)
            {
                SaveLog($"基本数据加载异常:{ex}");
            }
        }

        private void JoinPath() 
        {
            textftppth.Text = RegistryStorageHelper.CommonConnIPStr();
            textsqlpath.Text = RegistryStorageHelper.CommonConnSQLStr();
        }

        private void LoadStart() 
        {
            var startexe=RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationItemKey);
            SaveLog($"正在启动设置应用程序{startexe}");
            if (!string.IsNullOrEmpty(startexe)) 
            {
                CmdHelper.StartApp(startexe);
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
                        ctrl.Text = RegistryStorageHelper.GetValueFromReg<string>(ctrl.Tag.ToString());
                    }
                    if (code == 1) 
                    {
                        RegistryStorageHelper.SetValueToReg(ctrl.Tag.ToString(), ctrl.Text);
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

        static void GetFileSave(DirectoryInfo dirpath,string startStr)
        {
            FileInfo[] files = dirpath.GetFiles();
            DirectoryInfo[] directories = dirpath.GetDirectories();
            var pathname = dirpath.FullName.Replace($"{PathHelpStatus.Path}", "");
            if (GetRegValue(RegistryStorageKeys.StationFTPKey).Equals(startStr)) 
            {
                if (!string.IsNullOrEmpty(pathname))
                {
                    FtpHelper.MakeDir($"{pathname}");
                }
            }
            foreach (FileInfo item in files)
            {
                if (item.Name.Contains("AutoItemPack.exe") || item.Name.Contains("AutoItemPack.pdb"))
                {
                    continue;
                }

                if (GetRegValue(RegistryStorageKeys.StationFTPKey).Equals(startStr)) 
                {
                    fTPFileUoloads.Add(new FTPFileUoload { FileName = $"{Path.Combine(pathname, item.Name)}", FilePath = $"{pathname}" });
                    FtpHelper.FtpUploadBroken($"{dirpath}/{item.Name}", $"{Path.Combine(GetRegValue(RegistryStorageKeys.StartPathKey), pathname)}");
                }
                if (GetRegValue(RegistryStorageKeys.StationSQLKey).Equals(startStr)) 
                {
                    var infbytes = File.ReadAllBytes(dirpath + "\\" + item.Name);
                    SQLHelper.Save(infbytes, $"{pathname}{item.Name}", DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss"), pathname);
                }
            }
            foreach (DirectoryInfo item in directories)
            {
                GetFileSave(new DirectoryInfo(item.FullName), startStr);
            }
        }


        public static void ObjectToJson<T>(string jsonName, IList<T> IL)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (IL.Count > 0)
            {
                for (int i = 0; i < IL.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < IL.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            File.WriteAllText($@"{PathHelpStatus.Path}\downloadPath.txt", Json.ToString());
            FtpHelper.FtpUploadBroken($@"{PathHelpStatus.Path}\downloadPath.txt", GetRegValue(RegistryStorageKeys.StationFTPPathKey));
        }


        public static string GetRegValue(string key)
        {
            return RegistryStorageHelper.GetValueFromReg<string>(key);
        }

        private void textLog_TextChanged(object sender, EventArgs e)
        {
            this.textLog.SelectionStart = this.textLog.Text.Length;
            this.textLog.ScrollToCaret();
        }
    }
}
