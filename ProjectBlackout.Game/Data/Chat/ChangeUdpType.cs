using ProjectBlackout.Core;
using ProjectBlackout.Core.Models.Enums;
using ProjectBlackout.Game;
using ProjectBlackout.Game.Data.Configs;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class ChangeUdpType
    {
        public static string SetUdpType(string str)
        {
            int udpT = int.Parse(str.Substring(4));
            if ((UdpState)udpT == GameConfig.udpType)
            {
                return Translation.GetLabel("ChangeUDPAlready");
            }
            else if (udpT < 1 || udpT > 4)
            {
                return Translation.GetLabel("ChangeUDPWrongValue");
            }
            else
            {
                GameConfig.udpType = (UdpState)udpT;
                return Translation.GetLabel("ChangeUDPSuccess", GameConfig.udpType);
            }
        }
    }
}