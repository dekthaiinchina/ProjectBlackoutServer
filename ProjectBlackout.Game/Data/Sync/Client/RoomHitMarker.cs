using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Xml;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Model;
using System;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public static class RoomHitMarker
    {
        public static void Load(ReceiveGPacket p)
        {
            int roomId = p.readH();
            int channelId = p.readH();
            byte killerIdx = p.readC();
            byte deathtype = p.readC();
            byte hitEnum = p.readC();
            int damage = p.readH();
            if (p.getBuffer().Length > 11)
            {
                Logger.warning("Invalid Hit: " + BitConverter.ToString(p.getBuffer()));
            }
            Channel ch = ChannelsXml.getChannel(channelId);
            if (ch == null)
            {
                return;
            }
            Room room = ch.getRoom(roomId);
            if (room != null && room.RoomState == RoomState.Battle)
            {
                Account player = room.getPlayerBySlot(killerIdx);
                if (player != null)
                {
                    string warn = "";
                    if (deathtype == 10)
                    {
                        warn = Translation.GetLabel("LifeRestored", damage);
                    }
                    else if (hitEnum == 0)
                    {
                        warn = Translation.GetLabel("HitMarker1", damage);
                    }
                    else if (hitEnum == 1)
                    {
                        warn = Translation.GetLabel("HitMarker2", damage);
                    }
                    else if (hitEnum == 2)
                    {
                        warn = Translation.GetLabel("HitMarker3");
                    }
                    else if (hitEnum == 3)
                    {
                        warn = Translation.GetLabel("HitMarker4");
                    }
                    player.SendPacket(new PROTOCOL_LOBBY_CHATTING_ACK(Translation.GetLabel("HitMarkerName"), player.getSessionId(), 0, true, warn));
                }
            }
        }
    }
}