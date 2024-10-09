namespace Utilities.Constants;

public static class LoggingMessage
{
    // General calls
    public static string ActionCall(string methodName) => $"CALLED | [{methodName}]";
    public static string ActionCall(string reqType, string methodName) => $"CALLED | {reqType} | [{methodName}]";
    public static string ActionCall(string reqType, string methodName, string reqId) => $"CALLED | {reqType} | [{methodName}] with ID: '{reqId}'";

    // Fails/Errors
    public static string Failure(string reqType, string methodName) => $"FAILED | {reqType} | [{methodName}]";
    public static string Failure(string reqType, string methodName, string reqId) => $"FAILED | {reqType} | [{methodName}] with ID: '{reqId}'";
    public static string FailureWithException(string reqType, string methodName, string exceptionMessage) => $"FAILED | {reqType} | [{methodName}]\n{exceptionMessage}";
    public static string FailureWithException(string reqType, string methodName, string reqId, string exceptionMessage) => $"FAILED | {reqType} | [{methodName}] with ID: '{reqId}'\n{exceptionMessage}";
    public static string NotFound(string reqType, string methodName) => $"RECORD(S) NOT FOUND | {reqType} | [{methodName}]";
    public static string NotFound(string reqType, string methodName, string reqId) => $"RECORD(S) NOT FOUND | {reqType} | [{methodName}] with ID: '{reqId}'";
    public static string BadRequest(string reqType, string methodName) => $"BAD REQUEST | {reqType} | [{methodName}]";
    public static string BadRequest(string reqType, string methodName, string reqId) => $"BAD REQUEST | {reqType} | [{methodName}] with ID: '{reqId}'";

    // Success
    public static string Success(string reqType, string methodName) => $"SUCCESS | {reqType} | [{methodName}]";
    public static string Success(string reqType, string methodName, string reqId) => $"SUCCESS | {reqType} | [{methodName}] with ID: '{reqId}'";
    public static string Success(string reqType, string methodName, string reqId, string optionalOutput) => $"SUCCESS | {reqType} | [{methodName}] with ID: '{reqId}'\n{optionalOutput}";
}
