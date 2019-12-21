using Notebook;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.UserInterface
{
    public interface AddCommandUserInput
    {
        public string GetCommandType();
        public INote GetNote();
    }
}
