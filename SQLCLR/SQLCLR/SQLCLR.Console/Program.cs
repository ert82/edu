using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SQLCLR.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLRTests"].ConnectionString))
            {
                var assembly = GetHexString("SQLCLR.dll");

                var sql = $@"

                    DROP FUNCTION IF EXISTS [dbo].[SQLCLR_Math_Abs];

                    DROP ASSEMBLY IF EXISTS [SQLCLR];

                    CREATE ASSEMBLY [SQLCLR]
                    AUTHORIZATION [dbo]
                    FROM {assembly}
                    WITH PERMISSION_SET = SAFE;
                    ";

                connection.Open();
                connection.Execute(sql);

                connection.Execute(@"
                    CREATE FUNCTION [dbo].[SQLCLR_Math_Abs](@Input INT) RETURNS INT
                    AS EXTERNAL NAME SQLCLR.[SQLCLR.MathFunctions].Abs");
            }
        }

        static string GetHexString(string assemblyPath)
        {
            if (!Path.IsPathRooted(assemblyPath))
                assemblyPath = Path.Combine(Environment.CurrentDirectory, assemblyPath);

            StringBuilder builder = new StringBuilder();
            builder.Append("0x");

            using (FileStream stream = new FileStream(assemblyPath,
                  FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int currentByte = stream.ReadByte();
                while (currentByte > -1)
                {
                    builder.Append(currentByte.ToString("X2", CultureInfo.InvariantCulture));
                    currentByte = stream.ReadByte();
                }
            }

            return builder.ToString();
        }
    }
}
