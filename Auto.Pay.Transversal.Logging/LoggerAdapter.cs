using System.Collections.Generic;
using Auto.Pay.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace Auto.Pay.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(List<string> listMessages)
        {
            foreach (string message in listMessages)
            {
                _logger.LogError(message);
            }
        }

        public void LogInformation(List<string> listMessages)
        {
            foreach (string message in listMessages)
            {
                _logger.LogInformation(message);
            }
        }

        public void LogWarning(List<string> listMessages)
        {
            foreach (string message in listMessages)
            {
                _logger.LogWarning(message);
            }
        }
    }
}
