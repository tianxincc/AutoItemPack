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

        //最近一次登录站点
        public static readonly string StationKey = "LatestLoginStation";

        //上次登录用户名
        public static readonly string UserNameKey = "UserName";

        //上次登录名对应的密码
        public static readonly string UserPasswordKey = "UserPassword";

        //所有登录过的用户清单
        public static readonly string AllUsersKey = "AllUsers";

        //最近选择的打印机
        public static readonly string LastSelectedPrinter = "LastSelectedPrinter";

        //最近一次的库类别
        public static readonly string LastMedicalDB = "LastMedicalDB";

        /// <summary>
        /// 上一次选择的材块核对日期
        /// </summary>
        public static readonly string LastMaterialCheckStartDate = "LastMaterialCheckStartDate";

        /// <summary>
        /// 图像设备类型
        /// </summary>
        public static readonly string CamaraType = "CamaraType";

        /// <summary>
        /// 图像设备驱动
        /// </summary>
        public static readonly string CameraDriver = "CameraDriver";

        /// <summary>
        /// DShow设备名称
        /// </summary>
        public static readonly string DShowName = "DShowName";

        /// <summary>
        /// 快速录入配置基础字符串，用于和病例库ID拼接成为FastRegConfig-1，FastRegConfig-2等分库设置
        /// </summary>
        public static readonly string FastRegConfig = "FastRegConfig";

        /// <summary>
        /// 增加切片记录时记录的任务来源
        /// </summary>
        public static readonly string SliceSource = "SliceSource";

        /// <summary>
        /// 数据归档显示列配置
        /// </summary>
        public static readonly string DesignBookConfig = "DesignBookConfig";

        /// <summary>
        /// 包埋盒文本编码
        /// </summary>
        public static readonly string EmbeddingBoxEncoding = "EmbeddingBoxEncoding";

        /// <summary>
        /// 包埋盒文本编码
        /// </summary>
        public static readonly string CytologyChargeMedicalDb = "CytologyChargeMedicalDb";

        /// <summary>
        /// 自定义查询内容下拉框本地值
        /// </summary>
        public static readonly string QueryConditionContentString = "QueryConditionContentString";

        /// <summary>
        /// MVC3000设置
        /// </summary>
        public static readonly string MVC3000Setting = "MVC3000Setting";
        
    }
}
