using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_SELECT_CHANNEL_REQ : ReceivePacket
    {
        private int channelId;

        public PROTOCOL_BASE_SELECT_CHANNEL_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            channelId = readH();
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null || p.channelId >= 0)
            {
                return;
            }
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch != null)
            {
                if (ChannelRequirementCheck(p, ch))
                {
                    _client.SendPacket(new PROTOCOL_BASE_SELECT_CHANNEL_ACK(0x80000202));
                }
                else if (ch._players.Count >= GameConfig.maxChannelPlayers)
                {
                    _client.SendPacket(new PROTOCOL_BASE_SELECT_CHANNEL_ACK(0x80000201));
                }
                else
                {
                    p.channelId = channelId;
                    _client.SendPacket(new PROTOCOL_BASE_SELECT_CHANNEL_ACK(p.channelId, 0));
                    p._status.updateChannel((byte)p.channelId);
                    p.updateCacheInfo();
                }
            }
            else
            {
                _client.SendPacket(new PROTOCOL_BASE_SELECT_CHANNEL_ACK(0x80000000));
            }
            /*
             * 0x80000201 STBL_IDX_EP_SERVER_USER_FULL_C
             * 0x80000202 - De acordo com o ChannelType
             * 0x80000203 STBL_IDX_EP_SERVER_NOT_SATISFY_MTS
             * 0x80000204 STR_UI_GOTO_GWARNET_CHANNEL_ERROR
             * 0x80000205 STR_UI_GOTO_AZERBAIJAN_CHANNEL_ERROR
             * 0x80000206 STR_POPUP_MOBILE_CERTIFICATION_ERROR
             * 0x80000207 STR_UI_GOTO_TURKISH_CHANNEL_ERROR
             * 0x80000208 STR_UI_GOTO_MENA_CHANNEL_ERROR
             */
        }

        private bool ChannelRequirementCheck(Account p, Channel ch)
        {
            if (p.IsGM() || p.HaveAcessLevel())
            {
                return false;
            }
            if (ch._type == 4 && p.clanId == 0) //Canal de clã | Precisa de clã (Menos GM)
            {
                return true;
            }
            else if (ch._type == 3 && p._statistic.GetKDRatio() > 40) //Canal iniciante1 | KD abaixo de 40%
            {
                return true;
            }
            else if (ch._type == 2 && p._rank >= 4) //Canal iniciante2 | Entre Novato-Cabo
            {
                return true;
            }
            else if (ch._type == 5 && p._rank <= 25) //Canal avançado | Entre capitão 1-hero
            {
                return true;
            }
            else if (ch._type == -1) //Canal Bloqueiado
            {
                return true;
            }
            return false;
        }
    }
}