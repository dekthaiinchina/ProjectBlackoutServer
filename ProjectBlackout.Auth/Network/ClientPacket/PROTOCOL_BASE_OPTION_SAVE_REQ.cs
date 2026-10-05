using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Auth.Data.Model;

namespace ProjectBlackout.Auth.Network.ClientPacket
{
    public class PROTOCOL_BASE_OPTION_SAVE_REQ : ReceivePacket
    {
        private int type, value;
        private DBQuery query = new DBQuery();

        public PROTOCOL_BASE_OPTION_SAVE_REQ(AuthClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Account p = _client._player;
            if (p == null || p._config == null)
            {
                return;
            }
            type = readC();
            value = readC();
            readH();
            if ((type & 1) == 1)
            {
                p._config.blood = readH();
                p._config.sight = readC();
                p._config.hand = readC();
                p._config.config = readD();
                p._config.audio_enable = readC();
                readB(5);
                p._config.audio1 = readC();
                p._config.audio2 = readC();
                p._config.fov = readH();
                p._config.sensibilidade = readC();
                p._config.mouse_invertido = readC();
                readC();
                readC();
                p._config.msgConvite = readC();
                p._config.chatSussurro = readC();
                p._config.macro = readC();
                readC();
                readC();
                readC();
            }
            if ((type & 2) == 2)
            {
                readB(5);
                byte[] keysBuffer = readB(235);
                p._config.keys = keysBuffer;
            }
            if ((type & 4) == 4)
            {
                p._config.macro_1 = readUnicode(readC() * 2);
                p._config.macro_2 = readUnicode(readC() * 2);
                p._config.macro_3 = readUnicode(readC() * 2);
                p._config.macro_4 = readUnicode(readC() * 2);
                p._config.macro_5 = readUnicode(readC() * 2);
            }
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null || p._config == null)
            {
                return;
            }
            PlayerConfig config = p._config;
            if ((type & 1) == 1)
            {
                PlayerManager.updateConfigs(query, config);
            }
            if ((type & 2) == 2)
            {
                query.AddQuery("keys", config.keys);
            }
            if ((type & 4) == 4)
            {
                PlayerManager.updateMacros(query, config, value);
            }
            ComDiv.updateDB("player_configs", "owner_id", p.player_id, query.GetTables(), query.GetValues());
        }
    }
}