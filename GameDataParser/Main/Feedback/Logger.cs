using GameDataParser.Main.Interfaces;
using System;
using System.Text;

public class Logger
{

    private string _logFilePath;

    private IFileAccessable _fileAccess;

    public Logger(string logFilePath,IFileAccessable fileAccess)
    {
        _fileAccess = fileAccess;

        _logFilePath = logFilePath;
    }

    public void Log(Exception ex)
    {
        var logTime = '[' 
            + DateTime.Now.ToString("g")
            + "]";

        var exceptionMessage = "Exception message: " + ex.Message;

        string stackTrace = "Stackt trace: " 
            + Environment.NewLine
            + ex.StackTrace ?? "";

        var logEntry =new string[4] {
            logTime, 
            exceptionMessage, 
            stackTrace,
            Environment.NewLine,
        };

        _fileAccess.Write(_logFilePath, logEntry);
    }

}
