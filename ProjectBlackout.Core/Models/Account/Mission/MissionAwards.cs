namespace ProjectBlackout.Core.Models.Account.Mission
{
    public class MissionAwards
    {
        public int _id, _blueOrder, _exp, _gp;

        public MissionAwards(int id, int blueOrder, int exp, int gp)
        {
            _id = id;
            _blueOrder = blueOrder;
            _exp = exp;
            _gp = gp;
        }
    }
}