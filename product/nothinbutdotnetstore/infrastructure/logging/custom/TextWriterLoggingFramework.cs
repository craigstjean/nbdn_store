using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.custom
{
    public class TextWriterLoggingFramework : LoggingFramework
    {
        TextWriter writer;

        public TextWriterLoggingFramework(TextWriter writer)
        {
            this.writer = writer;
        }

        public void informational(string message)
        {
            writer.WriteLine(message);
        }
    }
}