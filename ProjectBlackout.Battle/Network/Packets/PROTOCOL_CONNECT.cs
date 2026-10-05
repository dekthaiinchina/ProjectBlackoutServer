
namespace ProjectBlackout.Battle.Network.Packets
{
    public class PROTOCOL_CONNECT
    {
        public static byte[] getCode()
        {
            using (SendPacket s = new SendPacket())
            {
                s.writeC(66);
                s.writeC(0);
                s.writeT(0);
                s.writeC(0);
                s.writeH(14);
                s.writeD(0);
                s.writeC(8);
                return s.mstream.ToArray();
            }
        }
    }
}