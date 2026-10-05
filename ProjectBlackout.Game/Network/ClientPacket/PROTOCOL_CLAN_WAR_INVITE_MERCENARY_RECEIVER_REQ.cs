using ProjectBlackout.Core;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_REQ : ReceivePacket
    {
        private int formacao;

        public PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            formacao = readC();
        }

        public override void run()
        {
            try
            {
                Account p = _client._player;
                if (p == null)
                {
                    return;
                }
                Match mt = p._match;
                if (mt != null && p.matchSlot == mt._leader)
                {
                    mt.formação = formacao;
                    using (PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_ACK packet = new PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_ACK(0, formacao))
                    {
                        mt.SendPacketToPlayers(packet);
                    }
                }
                else
                {
                    _client.SendPacket(new PROTOCOL_CLAN_WAR_INVITE_MERCENARY_RECEIVER_ACK(0x80000000));
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }
    }
}