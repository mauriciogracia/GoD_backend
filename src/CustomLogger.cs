
using System.IO;
using System ;

namespace GoD_backend
{
    public static class CustomLogger {
        private static StreamWriter logFile = null;

        public static void Init(string fileName) {
            try {
                logFile = new StreamWriter(fileName, true) ;
                logFile.AutoFlush = true ;
            }
            catch {
                // the log will be kept in the console no need to show this exception
            }
        }

        public static void WriteLine(string line) {
            string logLine ;

            logLine = string.Format("{0}:{1}",DateTime.Now, line) ;

            if(logFile != null)
            {
                logFile.WriteLine (logLine) ;
            }
            else 
            {
                Console.WriteLine(logLine) ;
            }
        }
    }
}