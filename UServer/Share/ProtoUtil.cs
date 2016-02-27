/**
 * 
 * Proto serialize and deserialize class
 * 
 * @author lazy
 *
 */
using System;
using System.IO;
using Share_Common;
using System.Text;
using ProtoBuf;
using System.Reflection;

namespace GameShare.Common
{
    public class ProtoUtil 
	{

		public static T Deserialize<T>(byte[] buffer) 
		{
			using (var stream = new MemoryStream(buffer)) 
			{
				return (T)Serializer.Deserialize<T>(stream);
			} 
		}

		public static T Deserialize<T>(ByteBuffer buffer)
		{
			byte[] data = buffer.ReadBytes ();

			return (T)Deserialize<T> (data);
		}

		public static byte[] Serialize<T>(T obj) 
		{
            using (var stream = new MemoryStream()) 
			{
                Serializer.Serialize(stream, obj);
                stream.Flush();
                return stream.ToArray();
            }
        }

		public static byte[] Serialize(ProtoBuf.IExtensible proto)
		{
			using (var stream = new MemoryStream()) 
			{
				Serializer.Serialize(stream, proto);
				stream.Flush();
				return stream.ToArray();
			}
		}

		public static C2S_Proto_Type GetProtoType(ProtoBuf.IExtensible proto)
		{
			PropertyInfo property = proto.GetType ().GetProperty ("type_t");
			if (null == property) 
			{
				Console.WriteLine ("Protocol {0} does not have memeber 'type-t'", proto);
				return C2S_Proto_Type.Proto_Stuff_Client_Begin;
			}
			String value = property.GetValue (proto, null).ToString ();
			C2S_Proto_Type type = C2S_Proto_Type.Proto_Stuff_Client_Begin;
			Enum.TryParse (value, out type);
			return type;
		}

    }
}
