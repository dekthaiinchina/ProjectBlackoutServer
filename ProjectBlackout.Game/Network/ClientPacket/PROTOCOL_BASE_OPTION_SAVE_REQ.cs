using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ClientPacket
{
    public class PROTOCOL_BASE_OPTION_SAVE_REQ : ReceivePacket
    {
        private int type, value;
        private DBQuery query = new DBQuery();

        public PROTOCOL_BASE_OPTION_SAVE_REQ(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            Account p = _client._player;
            if (p == null)
            {
                return;
            }
            bool ConfigIsValid = p._config != null;
            if (!ConfigIsValid)
            {
                ConfigIsValid = PlayerManager.CreateConfigDB(p.player_id);
                if (ConfigIsValid)
                {
                    p._config = new PlayerConfig();
                }
            }
            if (!ConfigIsValid)
            {
                return;
            }
            PlayerConfig config = p._config;
            type = readC();
            value = readC();
            readH();
            if ((type & 1) == 1)
            {
                config.blood = readH();
                config.sight = readC();
                config.hand = readC();
                config.config = readD();
                config.audio_enable = readC();
                readB(5);
                config.audio1 = readC();
                config.audio2 = readC();
                config.fov = readH();
                config.sensibilidade = readC();
                config.mouse_invertido = readC();
                readC();
                readC();
                config.msgConvite = readC();
                config.chatSussurro = readC();
                config.macro = readC();
                readC();
                readC();
                readC();
            }
            if ((type & 2) == 2)
            {
                readB(5);
                byte[] keysBuffer = readB(235);
                config.keys = keysBuffer;
            }
            if ((type & 4) == 4)
            {
                config.macro_1 = readUnicode(readC() * 2);
                config.macro_2 = readUnicode(readC() * 2);
                config.macro_3 = readUnicode(readC() * 2);
                config.macro_4 = readUnicode(readC() * 2);
                config.macro_5 = readUnicode(readC() * 2);
            }
        }

        public override void run()
        {
            Account p = _client._player;
            if (p == null)
            {
                return;
            }
            PlayerConfig config = p._config;
            if (config == null)
            {
                return;
            }
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
            ComDiv.updateDB("player_configs", "owner_id", _client.player_id, query.GetTables(), query.GetValues());
        }
    }
}