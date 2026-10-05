using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Core.Models.Room;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Utils;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BATTLE_ENDBATTLE_ACK : SendPacket
    {
        private Room r;
        private Account p;
        private int Winner = 2;
        private ushort PlayersFlag, MissionsFlag;
        private bool BotMode;

        public PROTOCOL_BATTLE_ENDBATTLE_ACK(Account p)
        {
            this.p = p;
            if (p != null)
            {
                r = p._room;
                if (r.RoomType == RoomType.Tutorial)
                {
                    Winner = 0;
                }
                else
                {
                    Winner = (int)AllUtils.GetWinnerTeam(r);
                }
                BotMode = r.isBotMode();
                AllUtils.getBattleResult(r, out MissionsFlag, out PlayersFlag);
            }
        }

        public PROTOCOL_BATTLE_ENDBATTLE_ACK(Account p, int Winner, ushort PlayersFlag, ushort MissionsFlag, bool BotMode)
        {
            this.p = p;
            this.Winner = Winner;
            this.PlayersFlag = PlayersFlag;
            this.MissionsFlag = MissionsFlag;
            this.BotMode = BotMode;
            if (p != null)
            {
                r = p._room;
            }
        }

        public PROTOCOL_BATTLE_ENDBATTLE_ACK(Account p, TeamResultType Winner, ushort PlayersFlag, ushort MissionsFlag, bool BotMode)
        {
            this.p = p;
            this.Winner = (int)Winner;
            this.PlayersFlag = PlayersFlag;
            this.MissionsFlag = MissionsFlag;
            this.BotMode = BotMode;
            if (p != null)
            {
                r = p._room;
            }
        }

        public override void write()
        {
            if (p == null || r == null)
            {
                return;
            }
            Clan clan = ClanManager.getClan(p.clanId);
            writeH(4116);
            writeH(PlayersFlag);
            writeC((byte)Winner);
            for (int i = 0; i < 16; i++)
            {
                Slot Slot = r._slots[i];
                writeH((ushort)Slot.exp);
            }
            for (int i = 0; i < 16; i++)
            {
                Slot Slot = r._slots[i];
                writeH((ushort)Slot.gp);
            }
            for (int i = 0; i < 16; i++)
            {
                Slot Slot = r._slots[i];
                writeC((byte)Slot.bonusFlags);
            }
            for (int i = 0; i < 16; i++)
            {
                Slot Slot = r._slots[i];
                writeH((ushort)Slot.BonusCafeExp);
                writeH((ushort)Slot.BonusItemExp);
                writeH((ushort)Slot.BonusEventExp);
            }
            for (int i = 0; i < 16; i++)
            {
                Slot Slot = r._slots[i];
                writeH((ushort)Slot.BonusCafePoint);
                writeH((ushort)Slot.BonusItemPoint);
                writeH((ushort)Slot.BonusEventPoint);
            }
            writeH(MissionsFlag);
            if (BotMode)
            {
                for (int i = 0; i < 16; i++)
                {
                    writeH((ushort)r._slots[i].Score);
                }
            }
            else if (r.RoomType == RoomType.Bomb || r.RoomType == RoomType.Annihilation || r.RoomType == RoomType.Boss || r.RoomType == RoomType.CrossCounter || r.RoomType == RoomType.Convoy || r.RoomType == RoomType.Defense || r.RoomType == RoomType.Destroy)
            {
                writeH((ushort)(r.RoomType == RoomType.Boss ? r.red_dino : (r.RoomType == RoomType.CrossCounter ? r._redKills : r.red_rounds)));
                writeH((ushort)(r.RoomType == RoomType.Boss ? r.blue_dino : (r.RoomType == RoomType.CrossCounter ? r._blueKills : r.blue_rounds)));
                for (int i = 0; i < 16; i++)
                {
                    writeC((byte)r._slots[i].objects);
                }
            }
            writeC(0);
            writeC(0);
            writeC(0);
            writeB(new byte[] 
            {
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF
            });
            writeC((byte)(p.player_name.Length * 2));
            writeUnicode(p.player_name, p.player_name.Length * 2);
            writeD(p.getRank());
            writeD(p.getRank());
            writeD(p._gp);
            writeD(p._exp);
            writeD(0);
            writeC(0);
            writeD(0);
            writeQ(0);
            writeC(0);
            writeC(0);
            writeD(p._money);
            writeD(clan._id);
            writeD(p.clanAccess);
            writeQ(0);
            writeC((byte)p.pc_cafe);
            writeC((byte)p.tourneyLevel);
            writeC((byte)(clan._name.Length * 2));
            writeUnicode(clan._name, clan._name.Length * 2);
            writeC((byte)clan._rank);
            writeC((byte)clan.getClanUnit());
            writeD(clan._logo);
            writeC((byte)clan._name_color);
            writeC((byte)clan.effect);
            writeD(p._statistic.fights);
            writeD(p._statistic.fights_win);
            writeD(p._statistic.fights_lost);
            writeD(p._statistic.fights_draw);
            writeD(p._statistic.kills_count);
            writeD(p._statistic.headshots_count);
            writeD(p._statistic.deaths_count);
            writeD(p._statistic.totalfights_count);
            writeD(p._statistic.totalkills_count);
            writeD(p._statistic.escapes);
            writeD(p._statistic.assist);
            writeD(p._statistic.fights);
            writeD(p._statistic.fights_win);
            writeD(p._statistic.fights_lost);
            writeD(p._statistic.fights_draw);
            writeD(p._statistic.kills_count);
            writeD(p._statistic.headshots_count);
            writeD(p._statistic.deaths_count);
            writeD(p._statistic.totalfights_count);
            writeD(p._statistic.totalkills_count);
            writeD(p._statistic.escapes);
            writeD(p._statistic.assist);
            writeH((short)p.Daily.Total); // Total
            writeH((short)p.Daily.Wins); // Wins
            writeH((short)p.Daily.Loses); // Loses
            writeH((short)p.Daily.Draws); // Draws
            writeH((short)p.Daily.Kills); // Kills
            writeH((short)p.Daily.Headshots); // Head Shots
            writeH((short)p.Daily.Deaths); // Deaths
            writeD(p.Daily.Exp); // Exp
            writeD(p.Daily.Point); // Point
            writeB(new byte[16]);
            writeC(0); // Play Time
            writeD(0); // Time
            writeD(0); // Time
        }
    }
}