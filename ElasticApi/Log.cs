namespace ElasticApi
{
	using System;
	using System.Diagnostics;

	public static class Log
	{
		public static void WriteLine (string message)
		{
			// mac os
			//Console.WriteLine(message);

			// windows
            Debug.WriteLine(message);
		}

		public static void WriteLine (string format, params object[] args)
		{
			// mac os
			//Console.WriteLine(string.Format(format, args));

			// windows
			Debug.WriteLine(string.Format(format, args));
		}
	}
}

