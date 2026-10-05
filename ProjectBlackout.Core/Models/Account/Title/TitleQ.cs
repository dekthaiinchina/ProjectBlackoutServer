namespace ProjectBlackout.Core.Models.Account.Title
{
    public class TitleQ
    {
        public int _id, _classId, _medals, _brooch, _blueOrder, _insignia, _rank, _slot, _req1, _req2;
        public long _flag;

        public TitleQ()
        {

        }

        public TitleQ(int titleId)
        {
            _id = titleId;
            _flag = ((long)1 << titleId);
        }
    }
}