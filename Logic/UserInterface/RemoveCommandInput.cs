using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.UserInterface
{
    [Attributes.CommonElement]
    public interface RemoveCommandInput
    {
        int GetRemoveNoteIndex();
        void ReportInvalidIndex();
    }
    
}
