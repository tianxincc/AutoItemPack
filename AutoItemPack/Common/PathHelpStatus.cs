using Common.Register;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public static class PathHelpStatus
    {
        //根路径
        public static readonly string Path = Directory.GetCurrentDirectory();

        //SQL链接路径
        public static readonly string ConnSQLStr = $"Data Source = {RegistryStorageKeys.StartSQLIPKeyStr}; Initial Catalog = {RegistryStorageKeys.StartSQLDBKeyStr}; Integrated Security = false; User ID = {RegistryStorageKeys.StartSQLUserKeyStr}; Password={RegistryStorageKeys.StartSQLPwdKeyStr}";

        //SQL链接路径
        public static readonly string ConnIPStr = $@"ftp://{RegistryStorageKeys.StartFTPIPKeyStr}:{RegistryStorageKeys.StartFTPPortKeyStr}/{RegistryStorageKeys.StartFTPPathKeyStr}";

        //GUID
        public static readonly string guid = Guid.NewGuid().ToString();

        //保存
        public static readonly int saveStatus = 1;

        //加载
        public static readonly int loadStatus = 0;

        

    }

    
}
