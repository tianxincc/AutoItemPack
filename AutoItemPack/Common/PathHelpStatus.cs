using Common.Register;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoItemPack.Common
{
    public static class PathHelpStatus
    {
        //根路径
        public static string Path = AppDomain.CurrentDomain.BaseDirectory;

       
        //GUID
        public static  string guid = Guid.NewGuid().ToString();

        //保存
        public static int saveStatus = 1;

        //加载
        public static int loadStatus = 0;

        //FTP路径文件名称
        public static string downloadPath = "downloadPath.txt";
        



    }

    
}
