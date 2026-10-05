using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_CS_REQUEST_INFO_ACK : SendPacket
    {
        private string text;
        private uint _erro;
        private Account p;

        public PROTOCOL_CS_REQUEST_INFO_ACK(long id, string txt)
        {
            text = txt;
            p = AccountManager.getAccount(id, 0);
            if (p == null || text == null)
            {
                _erro = 0x80000000;
            }
        }

        public override void write()
        {
            writeH(1845);
            writeD(_erro);
            if (_erro == 0)
            {
                writeQ(p.player_id);
                writeUnicode(p.player_name, 66);
                writeC((byte)p._rank);
                writeD(p._statistic.kills_count);
                writeD(p._statistic.deaths_count);
                writeD(p._statistic.fights);
                writeD(p._statistic.fights_win);
                writeD(p._statistic.fights_lost);
                writeUnicode(text, true);
            }
        }
    }
}