using System.Diagnostics;
using Newtonsoft.Json;

namespace Notebook
{
    public class StudentNote : INote
    {
        public string Name { get; set; }
        public string Group { get; set; }

        public StudentNote() { }
        
        [JsonConstructor]
        public StudentNote(string name, string group)
        {
            Name = name;
            Group = group;
        }
        public StudentNote(string content)
        {
            Debug.Assert(content != null, nameof(content) + " != null");
            var splittedContent = content.Split(",");
            Debug.Assert(splittedContent != null, nameof(splittedContent) + " != null");
            Name = splittedContent[0]?.Trim();
            Group = splittedContent[1]?.Trim();
        }

        public override string ToString()
        {
            return $"Student name: {Name}, group: {Group}";
        }

        private bool Equals(StudentNote another)
        {
            Debug.Assert(another != null, nameof(another) + " != null");
            Debug.Assert(another.Name != null, "another.Name != null");
            Debug.Assert(another.Group != null, "another.Group != null");
            return another.Name.Equals(Name) && another.Group.Equals(Group);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as StudentNote);
        }
    }
}