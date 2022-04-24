using Common;
using Common.Register;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutoItemPack.Common
{
    public static class SQLHelper
    {
        public static string guidstr = "";
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="infbytes">源数据</param>
        /// <param name="FileName">文件名</param>
        /// <param name="date">时间</param>
        public static void Save(byte[] infbytes, string FileName, string date, string dirfile)
        {
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                string sql = $"INSERT INTO UpdateFile([FileImage] ,[FileName] ,[UploadTime],[Guid],[DirFile]) VALUES(@infbytes ,@FileName,@date,@guid,@level,@dirfile)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.Add("@infbytes", SqlDbType.Binary);
                    cmd.Parameters.Add("@FileName", SqlDbType.Text);
                    cmd.Parameters.Add("@date", SqlDbType.Text);
                    cmd.Parameters.Add("@guid", SqlDbType.Text);
                    cmd.Parameters.Add("@dirfile", SqlDbType.Text);
                    cmd.Parameters["@infbytes"].Value = infbytes;
                    cmd.Parameters["@FileName"].Value = FileName;
                    cmd.Parameters["@date"].Value = date;
                    cmd.Parameters["@guid"].Value = PathHelpStatus.guid;
                    cmd.Parameters["@dirfile"].Value = dirfile;

                    int rows = cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// 数据库获更新
        /// </summary>
        public static void BtnUpdateFileToSQL()
        {
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                String sql = "select [FileImage] ,[FileName] ,[UploadTime],[DirFile] from UpdateFile";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var dirfile = sdr[3].ToString();
                    if (!string.IsNullOrEmpty(dirfile))
                    {
                        dirfile = Path.Combine(PathHelpStatus.Path, dirfile.Substring(1, dirfile.Length - 1));
                        if (!Directory.Exists(dirfile))
                        {
                            Directory.CreateDirectory(dirfile);
                        }
                    }
                    using (var fs = new FileStream(Path.Combine(PathHelpStatus.Path, sdr[1].ToString()), FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Write((byte[])sdr[0], 0, ((byte[])sdr[0]).Length);
                    }
                }
            }
        }

        /// <summary>
        /// 清空所有文件
        /// </summary>
        public static void BtnDeleteFile()
        {
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                String sql = $" truncate TABLE UpdateFile";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 判断是否更新
        /// </summary>
        /// <returns></returns>
        public static bool BtnIsDownload()
        {
            
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                string sql = "select [Id],[FileImage] ,[FileName] ,[UploadTime],[Guid] from UpdateFile where [Id]='1'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    guidstr = sdr["Guid"].ToString();
                }
                if (guidstr == RegistryStorageKeys.StartGUIDKeyStr)
                {
                    return false;
                }
            }
            return true;
        }

        public static void CreateFileTable()
        {
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                string sql = $" CREATE TABLE [dbo].[UpdateFile] (" +
                    $"[Id] int IDENTITY(1,1) NOT NULL," +
                    $"[FileImage] varbinary(max)  NULL," +
                    $"[FileName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL," +
                    $"[UploadTime] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL," +
                    $"[Guid] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,  " +
                    $"[DirFile] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL ) ";
                string sql1 = $"";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
            }
        }

        public static bool IsTable()
        {
            using (SqlConnection conn = new SqlConnection(PathHelpStatus.ConnSQLStr))
            {
                conn.Open();
                String sql = $" select count(1)   from information_schema.TABLES where TABLE_NAME = 'UpdateFile' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr.FieldCount > 0 ? false : true;
            }
        }

    }
}
