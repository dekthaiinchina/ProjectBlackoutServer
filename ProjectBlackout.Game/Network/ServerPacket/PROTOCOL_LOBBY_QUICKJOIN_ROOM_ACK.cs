using ProjectBlackout.Core.Models.Servers;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK : SendPacket
    {
        private uint Error;
        private List<QuickStart> Quicks;
        private QuickStart Select;
        private Room Room;

        public PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK(uint Error, List<QuickStart> Quicks = null, QuickStart Select = null, Room Room = null)
        {
            this.Error = Error;
            this.Quicks = Quicks;
            this.Select = Select;
            this.Room = Room;
        }

        public override void write()
        {
            writeH(5378);
            writeD(Error);
            for (int i = 0; i < Quicks.Count; i++)
            {
                QuickStart Quick = Quicks[i];
                writeC((byte)Quick.MapId);
                writeC((byte)Quick.Rule);
                writeC((byte)Quick.StageOptions);
                writeC((byte)Quick.Type);
            }
            if (Error == 0)
            {
                writeC((byte)Room._channelId);
                writeD(Room._roomId);
                writeH(1);
                if (Error != 0)
                {
                    writeC((byte)Select.MapId);
                    writeC((byte)Select.Rule);
                    writeC((byte)Select.StageOptions);
                    writeC((byte)Select.Type);
                }
                else
                {
                    writeC(0);
                    writeC(0);
                    writeC(0);
                    writeC(0);
                }
                writeD(0);
                writeD(0);
                writeD(0);
                writeD(0);
            }
        }
    }
}