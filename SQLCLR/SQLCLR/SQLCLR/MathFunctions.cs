using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLCLR
{
	public class MathFunctions
	{
		[SqlFunction]
		public static int Abs(int input) => Math.Abs(input);
	}
}
