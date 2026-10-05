using ProjectBlackout.Core.Managers;

namespace ProjectBlackout.Core.Models.Account.Clan
{
    public class Clan
    {
        public int _id, creationDate, partidas, vitorias, derrotas, autoridade, limite_rank, limite_idade, limite_idade2, _exp, _rank, _name_color, maxPlayers = 50, effect;
        public string _name = "", _info = "", _news = "";
        public long owner_id;
        public uint _logo = 4294967295;
        public float _pontos = 1000;
        public ClanBestPlayers BestPlayers = new ClanBestPlayers();

        public int getClanUnit()
        {
            return getClanUnit(PlayerManager.getClanPlayers(_id));
        }

        public int getClanUnit(int count)
        {
            //Possível 8 - "Top"
            if (count >= 250) return 7; //Corpo
            else if (count >= 200) return 6; //Divisão
            else if (count >= 150) return 5; //Brigada
            else if (count >= 100) return 4; //Regimento
            else if (count >= 50) return 3; //Batalhão
            else if (count >= 30) return 2; //Companhia
            else if (count >= 10) return 1; //Pelotão
            else return 0; //Esquadra
        }
    }
}