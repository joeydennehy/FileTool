using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Configuration;

namespace API.Config
{
	public static class ApplicationConfiguration
	{
		//private const string FILE_MASK_KEY = "FileMaskedConfig";
		public const string BASE_UPLOAD_PATH_KEY = "BaseUploadDirectory";
		public const string OUTPOUT_PATH_KEY = "OutputDirectory";

		private static Hashtable fileMaskSettings;

		public static string GetSetting(string configurationKeyName)
		{
			string value;
			Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
			try
			{
				value = config.AppSettings.Settings[configurationKeyName].Value;
			}
			catch(Exception)
			{
				return string.Empty;
			}
			return value;
		}

		/*public static Dictionary<string,string> FileMaskSettings
		{
			get
			{
				if (fileMaskSettings == null)
					fileMaskSettings = (Hashtable)ConfigurationManager.GetSection(FILE_MASK_KEY);
				
				SortedList<string, string> sl = new SortedList<string, string>();
				foreach (string key in fileMaskSettings.Keys)
				{
					sl.Add(key, (string)fileMaskSettings[key]);
				}

				return sl.ToDictionary(d => d.Key, d => d.Value);
			}
		}*/
	}
}
