using System;
using System.Runtime.Serialization;

namespace Vettel.Model
{
    [Serializable]
    public class User : ISerializable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public User()
        { }

        public User(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString(nameof(Name));
            Surname = info.GetString(nameof(Surname));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(Surname), Surname);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}";
        }
    }
}
