using System.Collections.Generic;

namespace Auto.Pay.Transversal.Common
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWarning(string message, params object[] args);

        void LogError(string message, params object[] args);

        void LogInformation(List<string> listMessages);

        void LogWarning(List<string> listMessages);

        void LogError(List<string> listMessagess);

    }
}
