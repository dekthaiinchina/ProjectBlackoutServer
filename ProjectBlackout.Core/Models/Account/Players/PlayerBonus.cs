namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerBonus
    {
        public int bonuses, sightColor = 4, muzzle = 0, freepass, fakeRank = 55;
        public string fakeNick = "";
        public long ownerId;

        public bool RemoveBonuses(int itemId)
        {
            int Dbonuses = bonuses, Dfreepass = freepass;
            if (itemId == 1600001) Decrease(1); //Exp 10%
            else if (itemId == 1600002) Decrease(2); //Exp 30%
            else if (itemId == 1600003) Decrease(4); //Exp 50%
            else if (itemId == 1600037) Decrease(8); //Exp 100%
            else if (itemId == 1600004) Decrease(32); //Gold 30%
            else if (itemId == 1600119) Decrease(64); //Gold 50%
            else if (itemId == 1600038) Decrease(128); //Gold 100%
            else if (itemId == 1600011) freepass = 0;
            return (bonuses != Dbonuses || freepass != Dfreepass);
        }

        public bool AddBonuses(int itemId)
        {
            int Dbonuses = bonuses, Dfreepass = freepass;
            if (itemId == 1600001) Increase(1);
            else if (itemId == 1600002) Increase(2);
            else if (itemId == 1600003) Increase(4);
            else if (itemId == 1600037) Increase(8);
            else if (itemId == 1600004) Increase(32);
            else if (itemId == 1600119) Increase(64);
            else if (itemId == 1600038) Increase(128);
            else if (itemId == 1600011) freepass = 1;
            return (bonuses != Dbonuses || freepass != Dfreepass);
        }

        private void Decrease(int value)
        {
            bonuses &= ~value;
        }

        private void Increase(int value)
        {
            bonuses |= value;
        }
    }
}