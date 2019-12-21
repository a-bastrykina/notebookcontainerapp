using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.UserInterface
{
    public interface RemoveCommandInput
    {
        int GetRemoveNoteIndex();
        void ReportInvalidIndex();
    }
    
}
