using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Vettel.Byte
{
    public class Binary<T> : IBinary<T> where T : ISerializable
    {
        private readonly BinaryFormatter _formatter;

        public Binary()
        {
            _formatter = new BinaryFormatter();
        }

        public byte[] Serialize(T data)
        {
            using (var memoryStream = new MemoryStream())
            {
                _formatter.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public T Deserialize(byte[] data)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                T value = (T) _formatter.Deserialize(memoryStream);

                return value;
            }
        }
    }
}
