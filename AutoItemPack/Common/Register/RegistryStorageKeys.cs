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

        //FTPIP
        public static readonly string StationFTPIPKey = "FTPIP";

        //FTP路径
        public static readonly string StationFTPPathKey = "FTPPath";

        //FTP端口
        public static readonly string StationFTPPortKey = "FTPPort";

        //FTP用户
        public static readonly string StationFTPUserKey = "FTPUser";

        //FTP密码
        public static readonly string StationFTPPwdKey = "FTPPwd";

        //SQL模式
        public static readonly string StationSQLKey = "SQL模式";

        //SQLIP
        public static readonly string StationSQLIPKey = "SQLIP";
        
        //SQLDB
        public static readonly string StationSQLDBKey = "SQLDB";

        //SQLUser
        public static readonly string StationSQLUserKey = "SQL账户";

        //SQLPwd
        public static readonly string StationSQLPwdKey = "SQL密码";

        //启动项目
        public static readonly string StationStartKey = "启动项目";

        //FTP路径
        public static readonly string StartPathKey = "FTP路径";

        //启动应用程序
        public static readonly string StationItemKey = "跟随启动";

        //GUID
        public static readonly string StationGUIDKey = "GUID";

        public static readonly string KeyY = "是";

        public static readonly string KeyN = "否";

        public static readonly string StationFTPKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationFTPKey);
        public static readonly string StationSQLKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationSQLKey);
        public static readonly string StationStartKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationStartKey);
        public static readonly string StartPathKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StartPathKey);
        public static readonly string StartGUIDKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationGUIDKey);

        public static readonly string StartFTPIPKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationFTPIPKey);
        public static readonly string StartFTPUserKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationFTPUserKey);
        public static readonly string StartFTPPwdKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationFTPPwdKey);
        public static readonly string StartFTPPathKeyStr = RegistryStorageHelper.GetValueFromReg<string>(StationFTPPathKey);



    }
}
