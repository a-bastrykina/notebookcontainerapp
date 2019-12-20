using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotebookTests.Mock
{
    
    public class TextWriterMock : TextWriter
    {
        public List<string> CapturedOutputs { get;  } = new List<string>();
        

        public override void WriteLine(string line)
        {
            CapturedOutputs.Add(line);
        }

        public override Encoding Encoding { get; }
    }
}