namespace INFOLINK.ShareLibs
{
    using System;

    public static class Logger
    {
        public enum Level
        {
            Info,
            Warning,
            Error
        };

        public static void Log(Logger.Level level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            Console.WriteLine(string.Format("{0}\t{1}", level.ToString(), message));
        }
    }
}
