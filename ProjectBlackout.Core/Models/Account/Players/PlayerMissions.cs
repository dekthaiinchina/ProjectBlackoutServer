using ProjectBlackout.Core.Network;

namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerMissions
    {
        public byte[] list1 = new byte[40], list2 = new byte[40], list3 = new byte[40], list4 = new byte[40];
        public int actualMission, card1, card2, card3, card4, mission1, mission2, mission3, mission4;

        public bool selectedCard;
        public PlayerMissions DeepCopy()
        {
            return (PlayerMissions)this.MemberwiseClone();
        }

        public byte[] getCurrentMissionList()
        {
            if (actualMission == 0)
            {
                return list1;
            }
            else if (actualMission == 1)
            {
                return list2;
            }
            else if (actualMission == 2)
            {
                return list3;
            }
            else
            {
                return list4;
            }
        }

        public int getCurrentCard()
        {
            return getCard(actualMission);
        }

        public int getCard(int index)
        {
            if (index == 0)
            {
                return card1;
            }
            else if (index == 1)
            {
                return card2;
            }
            else if (index == 2)
            {
                return card3;
            }
            else
            {
                return card4;
            }
        }

        public int getCurrentMissionId()
        {
            if (actualMission == 0)
            {
                return mission1;
            }
            else if (actualMission == 1)
            {
                return mission2;
            }
            else if (actualMission == 2)
            {
                return mission3;
            }
            else
            {
                return mission4;
            }
        }

        public void UpdateSelectedCard()
        {
            int currentCard = getCurrentCard();
            if (65535 == ComDiv.getCardFlags(getCurrentMissionId(), currentCard, getCurrentMissionList()))
            {
                selectedCard = true;
            }
        }
    }
}