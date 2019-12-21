using Notebook;
using System;
using System.Collections.Generic;
using System.Text;
using Attributes;

namespace Logic.UserInterface
{
    [ContainerElement]
    public interface AddCommandInput
    {
        INote GetNote();
    }
}
