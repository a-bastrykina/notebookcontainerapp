using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Notebook
{
    [Attributes.CommonElement]
    public class INotebook
    {
        public List<INote> Notes { get; set; } = new List<INote>();
    }
}