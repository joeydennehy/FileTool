using log4net;

namespace API.Logging
{
	public class Logger
	{
		private static readonly ILog LOG;

		static Logger()
		{
			if (LOG == null)
			{
				LOG = LogManager.GetLogger(typeof (Logger));
			}
		}


		public static void Log(string message, LogLevel type)
		{
			switch (type)
			{
				case LogLevel.Warn:
					LOG.Warn(message);
					break;
				case LogLevel.Debug:
					LOG.Debug(message);
					break;
				case LogLevel.Error:
					LOG.Error(message);
					break;
				case LogLevel.Info:
					LOG.Info(message);
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