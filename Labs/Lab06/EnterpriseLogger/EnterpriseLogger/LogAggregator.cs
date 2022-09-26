using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EnterpriseLogger
{
	public class LogAggregator
	{
		public string[] AggregateLogs(string logDirPath, int daysInPast)
		{
			var mergedLines = new List<string>();
			var filePaths = Directory.GetFiles(logDirPath, "*.log");
			foreach (var filePath in filePaths)
			{
				if (this.IsInDateRange(filePath, daysInPast))
				{
					mergedLines.AddRange(File.ReadAllLines(filePath));
				}
			}

			return mergedLines.ToArray();
		}

		private bool IsInDateRange(string filePath, int daysInPast)
		{
			string logName = Path.GetFileNameWithoutExtension(filePath);
			if (logName.Length < 8)
			{
				return false;
			}

			string logDayString = logName.Substring(logName.Length - 8, 8);
			DateTime logDay;
			DateTime today = DateTime.Today;
			if (DateTime.TryParseExact(logDayString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out logDay))
			{
				return logDay.AddDays(daysInPast) >= today;
			}

			return false;
		}
	}
}