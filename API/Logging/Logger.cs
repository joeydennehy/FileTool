using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace API.Logging
{
	public class Logger
	{
		protected static readonly ILog log;

	    static Logger()
	    {
		    if (log == null)
		    {
			   log = LogManager.GetLogger(typeof(Logger));
		    }
	    }
		 

		public static void Log(string message, LogLevel type)
		{
			switch (type)
			{
				case LogLevel.Warn:
					log.Warn(message);
					break;
				case LogLevel.Debug:
					log.Debug(message);
					break;
				case LogLevel.Error:
					log.Error(message);
					break;
				case LogLevel.Info:
					log.Info(message);
					break;

			}
		}
	}

	public enum LogLevel
	{
		Debug = 1,
		Warn = 2,
		Error = 3,
		Info = 4
	}
}
