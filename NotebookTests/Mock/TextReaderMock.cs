using System.Collections.Generic;
using System.IO;

namespace NotebookTests.Mock
{
    
    public class TextReaderMock : TextReader
    {
        private int _readLineCallCount = 0;
        private readonly List<string> _stringsToReturn = new List<string>();

        public TextReaderMock(List<string> mocks)
        {
            _stringsToReturn = mocks;
        }

        public override string ReadLine()
        {
            return _stringsToReturn[_readLineCallCount++];
        }
    }
}