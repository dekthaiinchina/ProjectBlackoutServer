using ProjectBlackout.Core.Models.Account.Clan;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Managers;

namespace ProjectBlackout.Game.Data.Sync.Client
{
    public class ClanServersSync
    {
        public static void Load(ReceiveGPacket p)
        {
            int type = p.readC();
            int clanId = p.readD();
            long ownerId;
            int date;
            string name, info;
            Clan clanCache = ClanManager.getClan(clanId);
            if (type == 0)
            {
                if (clanCache != null)
                {
                    return;
                }
                ownerId = p.readQ();
                date = p.readD();
                name = p.readS(p.readC());
                info = p.readS(p.readC());
                Clan clan = new Clan { _id = clanId, _name = name, owner_id = ownerId, _logo = 0, _info = info, creationDate = date };
                ClanManager.AddClan(clan);
            }
            else
            {
                if (clanCache != null)
                {
                    ClanManager.RemoveClan(clanCache);
                }
            }
        }
    }
}