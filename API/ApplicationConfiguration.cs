using System;
using System.Configuration;

namespace API
{
	public static class ApplicationConfiguration
	{
		public const string BASE_UPLOAD_PATH_KEY = "BaseUploadDirectory";

		public static string GetSetting(string configurationKeyName)
		{
			string value;
			Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetEntryAssembly().Location);
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

	}
}
