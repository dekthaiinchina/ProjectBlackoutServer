using ProjectBlackout.Core.Network;
using System;

namespace ProjectBlackout.Core.Models.Account
{
    public class AccountStatus
    {
        public long player_id;
        public byte channelId, roomId, clanFId, serverId;
        public byte[] buffer = new byte[4];

        public void ResetData(long player_id)
        {
            if (player_id == 0)
            {
                return;
            }
            int ch = channelId, room = roomId, clan = clanFId, server = serverId;
            SetData(4294967295, player_id);
            if (ch != channelId || room != roomId || clan != clanFId || server != serverId)
            {
                ComDiv.updateDB("players", "status", (long)4294967295, "player_id", player_id);
            }
        }

        public void SetData(uint uintData, long pId)
        {
            SetData(BitConverter.GetBytes(uintData), pId);
        }

        public void SetData(byte[] buffer, long pId)
        {
            player_id = pId;
            this.buffer = buffer;
            channelId = buffer[0];
            roomId = buffer[1];
            serverId = buffer[2];
            clanFId = buffer[3];
        }

        public void updateChannel(byte channelId)
        {
            this.channelId = channelId;
            buffer[0] = channelId;
            UpdateDB();
        }

        public void updateRoom(byte roomId)
        {
            this.roomId = roomId;
            buffer[1] = roomId;
            UpdateDB();
        }

        public void updateServer(byte serverId)
        {
            this.serverId = serverId;
            buffer[2] = serverId;
            UpdateDB();
        }

        public void updateClanMatch(byte clanFId)
        {
            this.clanFId = clanFId;
            buffer[3] = clanFId;
            UpdateDB();
        }

        private void UpdateDB()
        {
            uint value = BitConverter.ToUInt32(buffer, 0);
            ComDiv.updateDB("players", "status", (long)value, "player_id", player_id);
        }
    }
}