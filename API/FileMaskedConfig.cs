using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace API
{
	class FileMaskedConfig : ConfigurationSection
	{
		private static readonly Hashtable settings = (Hashtable)ConfigurationManager.GetSection("FileMaskedConfig");

		public static Dictionary<string,string> Settings
		{
			get
			{
				return settings.Cast<DictionaryEntry>().ToDictionary(d => (string)d.Key, d => (string)d.Value);
			}
		}
	}
}
