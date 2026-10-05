using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using System;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_CS_CLIENT_CLAN_LIST_REQ : ReceivePacket
    {
        private uint page;

        public PROTOCOL_CS_CLIENT_CLAN_LIST_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            page = readUD();
        }

        public override void run()
        {
            try
            {
                if (_client == null || _client._player == null)
                {
                    return;
                }
                int count = 0;
                using (SendGPacket p = new SendGPacket())
                {
                    lock (ClanManager._clans)
                    {
                        for (int i = (int)page * 15; i < ClanManager._clans.Count; i++)
                        {
                            Clan clan = ClanManager._clans[i];
                            WriteData(clan, p);
                            if (++count == 15)
                            {
                                break;
                            }
                        }
                    }
                    _client.SendPacket(new PROTOCOL_CS_CLIENT_CLAN_LIST_ACK(page, count, p.mstream.ToArray()));
                }
            }
            catch (Exception ex)
            {
                Logger.warning(ex.ToString());
            }
        }

        private void WriteData(Clan clan, SendGPacket p)
        {
            p.writeD(clan._id);
            p.writeUnicode(clan._name, 34);
            p.writeC((byte)clan._rank);
            p.writeC((byte)PlayerManager.getClanPlayers(clan._id));
            p.writeC((byte)clan.maxPlayers);
            p.writeD(clan.creationDate);
            p.writeD(clan._logo);
            p.writeC((byte)clan._name_color);
            //p.writeC((byte)clan.effect);
            p.writeD(clan.partidas);
            p.writeD(clan.vitorias);
            p.writeD(clan.derrotas);
            p.writeD(0); // ?
            p.writeF(clan._pontos);
            p.writeF(clan._pontos);
            p.writeC(0); // ?
            p.writeH((short)clan._name.Length);
            p.writeUnicode(clan._name, clan._name.Length * 2);
        }
    }
}