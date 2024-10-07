namespace CommonDefinitions
{
    public interface ILogger
    {
        void Log<T>(T message, LogLevel level);   
    }

    public static class ILoggerExtensions
    {
        public static void Info<T>(this ILogger logger, T message)
        {
            logger.Log(message, LogLevel.Information);
        }
    }

}
