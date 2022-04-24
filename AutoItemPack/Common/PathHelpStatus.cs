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
        public static readonly string ConnSQLStr = $"Data Source = {RegistryStorageKeys.StationSQLIPKey}; Initial Catalog = {RegistryStorageKeys.StationSQLDBKey}; Integrated Security = false; User ID = {RegistryStorageKeys.StationSQLUserKey}; Password={RegistryStorageKeys.StationSQLPwdKey}";

        //SQL链接路径
        public static readonly string ConnIPStr = $@"ftp://{RegistryStorageKeys.StationFTPIPKey}:{RegistryStorageKeys.StationFTPPortKey}/{RegistryStorageKeys.StationFTPPathKey}";

        //GUID
        public static readonly string guid = Guid.NewGuid().ToString();

    }
}
