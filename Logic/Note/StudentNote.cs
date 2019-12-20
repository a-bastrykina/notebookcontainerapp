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
            var splittedContent = content.Split(",");
            Name = splittedContent[0].Trim();
            Group = splittedContent[1].Trim();
        }

        public override string ToString()
        {
            return Name + ", " + Group;
        }

        private bool Equals(StudentNote another)
        {
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