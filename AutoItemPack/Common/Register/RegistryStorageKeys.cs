using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Register
{
    public static class RegistryStorageKeys
    {
        //注册表根路径
        public static readonly string RegPath = @"SOFTWARE\AutoItemPack";

        //FTP模式
        public static readonly string StationFTPKey = "FTP模式";
        public static readonly string StationFTPKeyStr = GetRegValue(StationFTPKey);


        //FTPIP
        public static readonly string StationFTPIPKey = "FTPIP";
        public static readonly string StartFTPIPKeyStr = GetRegValue(StationFTPIPKey);


        //FTP路径
        public static readonly string StationFTPPathKey = "FTP路径";
        public static readonly string StartFTPPathKeyStr = GetRegValue(StationFTPPathKey);


        //FTP端口
        public static readonly string StationFTPPortKey = "FTP端口";
        public static readonly string StartFTPPortKeyStr = GetRegValue(StationFTPPortKey);

        //FTP用户
        public static readonly string StationFTPUserKey = "FTP账户";
        public static readonly string StartFTPUserKeyStr = GetRegValue(StationFTPUserKey);


        //FTP密码
        public static readonly string StationFTPPwdKey = "FTP密码";
        public static readonly string StartFTPPwdKeyStr = GetRegValue(StationFTPPwdKey);


        //SQL模式
        public static readonly string StationSQLKey = "SQL模式";
        public static readonly string StationSQLKeyStr = GetRegValue(StationSQLKey);

        //SQLIP
        public static readonly string StationSQLIPKey = "SQLIP";
        public static readonly string StartSQLIPKeyStr = GetRegValue(StationSQLIPKey);


        //SQLDB
        public static readonly string StationSQLDBKey = "SQLDB";
        public static readonly string StartSQLDBKeyStr = GetRegValue(StationSQLDBKey);


        //SQLUser
        public static readonly string StationSQLUserKey = "SQL账户";
        public static readonly string StartSQLUserKeyStr = GetRegValue(StationSQLUserKey);


        //SQLPwd
        public static readonly string StationSQLPwdKey = "SQL密码";
        public static readonly string StartSQLPwdKeyStr = GetRegValue(StationSQLPwdKey);


        //启动项目
        public static readonly string StationStartKey = "启动项目";
        public static readonly string StationStartKeyStr = GetRegValue(StationStartKey);


        //FTP路径
        public static readonly string StartPathKey = "FTP路径";
        public static readonly string StartPathKeyStr = GetRegValue(StartPathKey);


        //启动应用程序
        public static readonly string StationItemKey = "跟随启动";
        public static readonly string StartItemKeyStr = GetRegValue(StationItemKey);

        //GUID
        public static readonly string StationGUIDKey = "GUID";
        public static readonly string StartGUIDKeyStr = GetRegValue(StationGUIDKey);


        public static readonly string KeyY = "是";

        public static readonly string KeyN = "否";



        public static string GetRegValue(string key)
        {
            return RegistryStorageHelper.GetValueFromReg<string>(key);
        }

    }
}
