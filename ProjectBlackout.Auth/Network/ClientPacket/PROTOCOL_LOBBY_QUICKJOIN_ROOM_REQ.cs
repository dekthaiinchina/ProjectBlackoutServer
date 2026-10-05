using ProjectBlackout.Auth.Network.ServerPacket;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ : ReceivePacket
    {
        private int Select;
        private List<QuickStart> Quicks = new List<QuickStart>();

        public PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(AuthClient Client, byte[] Buffer)
        {
            makeme(Client, Buffer);
        }

        public override void read()
        {
            Select = readC();
            for (int i = 0; i < 3; i++)
            {
                QuickStart Quick = new QuickStart();
                Quick.MapId = readC();
                Quick.Rule = readC();
                Quick.StageOptions = readC();
                Quick.Type = readC();
                Quicks.Add(Quick);
            }
        }

        public override void run()
        {
            try
            {
                _client.SendPacket(new PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK("Мы бригада программистов, он держит нас в заперти. \nИ платит только завтраками :( \nСкажите ему чтобы он начал платить нам. \nХотя бы едой :("));
            }
            catch (Exception ex)
            {
                Logger.error("PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ: " + ex.ToString());
            }
        }
    }
}
