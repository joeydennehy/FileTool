﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Resources
{
	public static class ResourceReader
	{
		private static readonly ResourceManager RESOURCE_MANAGER;

		static ResourceReader()
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			RESOURCE_MANAGER = new ResourceManager("DataProvider.SQL.Statement", Assembly.GetExecutingAssembly());
		}

		public static string GetSql(string id)
		{
			return RESOURCE_MANAGER.GetString(id);
		}
	}
}
