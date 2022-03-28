using System;
using System.IO;

namespace BarsEdu
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringLogger = new LocalFileLogger<string>("logs.txt");
            stringLogger.LogInfo("stringLogger LogInfo");
            stringLogger.LogWarning("stringLogger LogWarning");
            stringLogger.LogError("stringLogger LogError", new NullReferenceException());

            var intLogger = new LocalFileLogger<int>("logs.txt");
            intLogger.LogInfo("intLogger LogInfo");
            intLogger.LogWarning("intLogger LogWarning");
            intLogger.LogError("intLogger LogError", new NullReferenceException());

            var boolLogger = new LocalFileLogger<bool>("logs.txt");
            boolLogger.LogInfo("boolLogger LogInfo");
            boolLogger.LogWarning("boolLogger LogWarning");
            boolLogger.LogError("boolLogger LogError", new NullReferenceException());
        }
    }
}