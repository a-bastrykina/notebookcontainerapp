using System;
using System.Runtime.Serialization;
using Attributes;
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
            var splittedContent = content.Split(",");
            Name = splittedContent[0].Trim();
            Phone = splittedContent[1].Trim();
        }

        public override string ToString()
        {
            return Name + ", " + Phone;
        }

        private bool Equals(PhoneNote another)
        {
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