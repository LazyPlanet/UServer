using System;
using System.Text;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;

namespace GameServer.NetWork 
{
    class ReceiveFilter : FixedHeaderReceiveFilter<BinaryRequestInfo> 
	{
		public ReceiveFilter() : base(2) 
		{
			
        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length) 
		{
            return (ushort)header[offset];
        }

        protected override BinaryRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] buffer, int offset, int length) 
		{
            return new BinaryRequestInfo(null, buffer.CloneRange(offset, length));
        }
    }
}
