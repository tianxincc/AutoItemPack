using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Register
{
    public static class RegistryStorageKeys
    {
        //注册表根路径
        public static string RegPath = @"SOFTWARE\AutoItemPack";

        //FTP模式
        public static string StationFTPKey = "FTP模式";
        //public static string StationFTPKeyStr = GetRegValue(StationFTPKey);


        //FTPIP
        public static string StationFTPIPKey = "FTPIP";
        //public static string StartFTPIPKeyStr = GetRegValue(StationFTPIPKey);


        //FTP路径
        public static string StationFTPPathKey = "FTP路径";
        //public static string StartFTPPathKeyStr = GetRegValue(StationFTPPathKey,2);
        

        //FTP端口
        public static string StationFTPPortKey = "FTP端口";
        //public static string StartFTPPortKeyStr = GetRegValue(StationFTPPortKey);

        //FTP用户
        public static string StationFTPUserKey = "FTP账户";
        //public static string StartFTPUserKeyStr = GetRegValue(StationFTPUserKey);


        //FTP密码
        public static string StationFTPPwdKey = "FTP密码";
        //public static string StartFTPPwdKeyStr = GetRegValue(StationFTPPwdKey);


        //SQL模式
        public static string StationSQLKey = "SQL模式";
        //public static string StationSQLKeyStr = GetRegValue(StationSQLKey);

        //SQLIP
        public static string StationSQLIPKey = "SQLIP";
        //public static string StartSQLIPKeyStr = GetRegValue(StationSQLIPKey);


        //SQLDB
        public static string StationSQLDBKey = "SQLDB";
        //public static string StartSQLDBKeyStr = GetRegValue(StationSQLDBKey);


        //SQLUser
        public static string StationSQLUserKey = "SQL账户";
        //public static string StartSQLUserKeyStr = GetRegValue(StationSQLUserKey);


        //SQLPwd
        public static string StationSQLPwdKey = "SQL密码";
        //public static string StartSQLPwdKeyStr = GetRegValue(StationSQLPwdKey);


        //启动项目
        public static string StationStartKey = "启动项目";
        //public static string StationStartKeyStr = GetRegValue(StationStartKey);


        //FTP路径
        public static string StartPathKey = "FTP路径";
        //public static string StartPathKeyStr = GetRegValue(StartPathKey);


        //启动应用程序
        public static string StationItemKey = "跟随启动";
        //public static string StartItemKeyStr = GetRegValue(StationItemKey);

        //GUID
        public static string StationGUIDKey = "GUID";
        //public static string StartGUIDKeyStr = GetRegValue(StationGUIDKey);


        public static string KeyY = "是";

        public static string KeyN = "否";


    }
}
