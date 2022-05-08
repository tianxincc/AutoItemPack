using System;
using System.Diagnostics;
using System.IO;

using Microsoft.Win32;

namespace Common.Register
{
    /// <summary>
    /// 注册表工具类
    /// </summary>
    public static class RegistryStorageHelper
    {


        public static string CommonConnSQLStr() 
        {
            return $"Data Source = {RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationSQLIPKey)}; Initial Catalog = {RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationSQLDBKey)}; Integrated Security = false; User ID = { RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationSQLUserKey)}; Password={RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationSQLPwdKey)}";
        }

        public static string CommonConnIPStr() 
        {
            return $@"ftp://{RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationFTPIPKey) }:{RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationFTPPortKey)}/{RegistryStorageHelper.GetValueFromReg<string>(RegistryStorageKeys.StationFTPPathKey)}";
        }


        //下方为通用方法，如不需要封装可以简单调用

        /// <summary>
        /// 设置Bool值
        /// </summary>
        /// <param name="station"></param>
        public static void SetBool(string key, bool value)
        {
            var v = value ? 1 : 0;
            SetValueToReg(key, v);
        }

        /// <summary>
        /// 获取Bool值
        /// </summary>
        /// <returns></returns>
        public static bool GetBool(string key)
        {
            var result = GetValueFromReg<int>(key);
            return result == 1 ? true : false;
        }

        public static T GetValueFromReg<T>(string key)

        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(RegistryStorageKeys.RegPath);
            var val = registryKey.GetValue(key);

            if (val is T)
            {
                return (T)val;
            }
            try
            {
                return (T)Convert.ChangeType(val, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        public static void SetValueToReg(string key, object value)
        {
            var registryKey = Registry.CurrentUser.CreateSubKey(RegistryStorageKeys.RegPath);
            if (registryKey == null)
            {
                throw new Exception($"创建{RegistryStorageKeys.RegPath}时出现异常");
            }

            if (value is Enum)
            {
                value = (int)value;
            }
            registryKey.SetValue(key, value);
            registryKey.Close();
        }

        /// <summary>
        /// 导出路径
        /// </summary>
        /// <param name="filepath"></param>
        public static void Export(string filepath)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = $@"reg export ""HKCU\{RegistryStorageKeys.RegPath}""  ""{filepath}\reg.reg"" /y ";
                    proc.Start();
                    //string stdout = proc.StandardOutput.ReadToEnd();
                    //string stderr = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                // handle exception
            }
        }

    }
}
