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
        /// <summary>
        /// 设置上次登录的站点
        /// </summary>
        /// <param name="station"></param>
        //public static void SetLoginStationToReg(Station station)
        //{
        //    SetValueToReg(RegistryStorageKeys.StationKey, station);
        //}

        /// <summary>
        /// 获取上次登录的站点
        /// </summary>
        /// <returns></returns>
        //public static int GetLoginStationFromReg()
        //{
        //    return GetValueFromReg<int>(RegistryStorageKeys.StationKey);
        //}

        /// <summary>
        /// 设置上次登录的病理库
        /// </summary>
        /// <param name="station"></param>
        //public static void SetLastMedicalDB(CaseDbType dbtype)
        //{
        //    SetValueToReg(RegistryStorageKeys.LastMedicalDB, (int)dbtype);
        //}

        /// <summary>
        /// 获取上次登录的病理库
        /// </summary>
        /// <returns></returns>
        //public static int GetLastMedicalDB()
        //{
        //    var result = GetValueFromReg<int>(RegistryStorageKeys.LastMedicalDB);
        //    return result == 0 ? (int)CaseDbType.Common : result;
        //}

        //public static void SetLoginUserNameFromReg(string userName)
        //{
        //    //如果test不调用 就可以删掉了
        //    SetValueToReg(RegistryStorageKeys.UserNameKey, userName);
        //}

        //public static void AddUserToReg(string name, string password)
        //{
        //    SetValueToReg(RegistryStorageKeys.UserNameKey, name);
        //    SetValueToReg(RegistryStorageKeys.UserPasswordKey, password);

        //    string allUsers = GetAllUsersFromReg();

        //    if (!string.IsNullOrEmpty(allUsers))
        //    {
        //        string newUser = name + "|" + password;
        //        if (!allUsers.Contains(newUser))
        //        {
        //            allUsers += "," + newUser;
        //        }
        //    }
        //    else
        //    {
        //        allUsers = name + "|" + password;
        //    }
        //    SetValueToReg(RegistryStorageKeys.AllUsersKey, allUsers);

        //}
        //public static string GetLoginUserNameFromReg()
        //{
        //    return GetValueFromReg<string>(RegistryStorageKeys.UserNameKey);
        //}
        //public static string GetLoginPasswordFromReg()
        //{
        //    return GetValueFromReg<string>(RegistryStorageKeys.UserPasswordKey);
        //}

        //public static string GetAllUsersFromReg()
        //{
        //    return GetValueFromReg<string>(RegistryStorageKeys.AllUsersKey);
        //}


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
