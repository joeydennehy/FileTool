using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace DataProvider.MySQL
{
	public class CommandParameters
	{
		public void Add(MySqlParameter item)
		{
			throw new NotImplementedException();
		}

		#region Private Members

		private readonly List<MySqlParameter> parameters = null;

		#endregion

		public CommandParameters()
		{
			parameters = new List<MySqlParameter>();
		}

		public Array ParameterCollection
		{
			get
			{
				return parameters.ToArray();
			}
		}

		public void Add(DbType dataType, string paramId, object paramValue)
		{
			if (paramId.IndexOf('@') != 1)
				paramId = string.Format("@{0}", paramId);

			MySqlParameter param = new MySqlParameter() 
			{
				DbType = dataType,
				Direction = ParameterDirection.Input,
				ParameterName = paramId,
			};

			param.Value = paramValue == null ? DBNull.Value : paramValue;
			
			parameters.Add(param);
		}
	}
}
