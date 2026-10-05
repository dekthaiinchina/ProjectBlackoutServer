using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public static class ClanSync
    {
        public static void Load(ReceiveGPacket p)
        {
            long playerId = p.readQ();
            int type = p.readC();
            Account player = AccountManager.getAccount(playerId, true);
            if (player == null)
            {
                return;
            }

            if (type == 3)
            {
                int clanId = p.readD();
                int clanAccess = p.readC();
                player.clanId = clanId;
                player.clanAccess = clanAccess;
            }
        }
    }
}