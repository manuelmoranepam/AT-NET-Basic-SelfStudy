using System;

namespace LoggerLibrary.Interfaces.Loggers;

public interface ILoggerService
{
	void LogCritical(Exception exception, string message, params object?[]? args);
	void LogError(Exception exception, string message, params object?[]? args);
	void LogInformation(string message, params object?[]? args);
	void LogWarning(string message, params object?[]? args);
	void CloseAndFlush();
}
