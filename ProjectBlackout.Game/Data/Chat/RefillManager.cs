using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Game.Network.ServerPacket;
using ProjectBlackout.Game.Data.Managers;
using ProjectBlackout.Game.Data.Model;
using System;
using ProjectBlackout.Core.Models.Enums;

namespace ProjectBlackout.Game.Data.Chat
{
    public static class RefillManager
    {
        public static string RefillPlayer(string str)
        {
            try
            {
                string card_number = str.Substring(7);
                if (card_number == null)
                {
                    return Translation.GetLabel("RefillGame");
                }
                else
                {
                    if(card_number.Length != 14)
                    {
                        return Translation.GetLabel("RefillGame1");
                    }
                    else
                    {
                        // CODE TOPUP
                        return Translation.GetLabel("RefillGame2",card_number);
                    }
                }
            }
            catch
            {
                return Translation.GetLabel("RefillGame");
            }
        }        
    }
}