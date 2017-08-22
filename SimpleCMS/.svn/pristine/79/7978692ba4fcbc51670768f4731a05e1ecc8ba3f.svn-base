using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Core;
using log4net.Layout;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Shura.SimpleCMS.Logic
{
    public class LoggingSystem
    {


        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Logs error the an XML file using Log4net
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName">File name that exception occurred in</param>
        public static void LogError(Exception ex, string fileName)
        {
            Log.Error(ex.ToString() + " in " + fileName);
        }

        /// <summary>
        /// Logs error the an XML file using Log4net
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            Log.Error(message);
        }

        /// <summary>
        /// Maps the error to its error message from resources
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string GetErrorMessage(Enums.SystemErrors error)
        {
            //switch (error)
            //{

            //}
            return "";
        }
    }
    /// <summary>
    /// This class is used in logging with log4net to generate XML file
    /// </summary>
    public class MyXmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteStartElement("LogEntry");
            writer.WriteStartElement("Time");
            writer.WriteString(loggingEvent.TimeStamp.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Message");
            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
