using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Notebook
{
    [Attributes.CommonElement]
    public class INotebook
    {
        [NotNull]
        public List<INote> Notes { get; set; } = new List<INote>();
    }
}