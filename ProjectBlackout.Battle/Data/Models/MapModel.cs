using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlackout.Battle.Data.Models
{
    public class MapModel
    {
        public int Id;
        public List<ObjectModel> Objects = new List<ObjectModel>();
        public List<BombPosition> Bombs = new List<BombPosition>();

        public BombPosition GetBomb(int BombId)
        {
            try
            {
                return Bombs[BombId];
            }
            catch
            {
                return null;
            }
        }
    }
}
