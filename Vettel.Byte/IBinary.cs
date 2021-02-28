using System.Runtime.Serialization;

namespace Vettel.Byte
{
    public interface IBinary<T> where T : ISerializable
    {
        byte[] Serialize(T data);
        T Deserialize(byte[] data);
    }
}
