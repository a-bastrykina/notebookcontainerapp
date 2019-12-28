using System.Diagnostics;
using Newtonsoft.Json;

namespace Notebook
{
    public class PhoneNote : INote
    {
        public string Name { get; set; } 
        public string Phone { get; set; }

        public PhoneNote() { }
        
        [JsonConstructor]
        public PhoneNote(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        
        public PhoneNote(string content)
        {
            Debug.Assert(content != null, nameof(content) + " != null");
            var splittedContent = content.Split(",");
            Debug.Assert(splittedContent != null, nameof(splittedContent) + " != null");
            Name = splittedContent[0]?.Trim();
            Phone = splittedContent[1]?.Trim();
        }

        public override string ToString()
        {
            return $"Name: {Name}, phone number: {Phone}";
        }

        private bool Equals(PhoneNote another)
        {
            Debug.Assert(another != null, nameof(another) + " != null");
            Debug.Assert(another.Name != null, "another.Name != null");
            Debug.Assert(another.Phone != null, "another.Phone != null");
            return another.Name.Equals(Name) && another.Phone.Equals(Phone);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as PhoneNote);
        }
    }
}