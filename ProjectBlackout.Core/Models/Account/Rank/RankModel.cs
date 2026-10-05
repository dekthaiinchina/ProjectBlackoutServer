namespace ProjectBlackout.Core.Models.Account.Rank
{
    public class RankModel
    {
        public int _onNextLevel, _id, _onGPUp, _onAllExp;

        public RankModel(int rank, int onNextLevel, int onGPUp, int onAllExp)
        {
            _id = rank;
            _onNextLevel = onNextLevel;
            _onGPUp = onGPUp;
            _onAllExp = onAllExp;
        }
    }
}