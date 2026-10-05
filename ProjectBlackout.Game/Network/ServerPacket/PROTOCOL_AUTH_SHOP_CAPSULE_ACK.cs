using ProjectBlackout.Core;
using ProjectBlackout.Core.Managers;
using ProjectBlackout.Core.Models.Account.Players;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Sync.Server;
using System;
using System.Collections.Generic;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_AUTH_SHOP_CAPSULE_ACK : SendPacket
    {
        private List<ItemsModel> Rewards;
        private int CouponId, Index;

        public PROTOCOL_AUTH_SHOP_CAPSULE_ACK(List<ItemsModel> Rewards, int CouponId, int Index)
        {
            this.CouponId = CouponId;
            this.Index = Index;
            this.Rewards = Rewards;
        }

        public override void write()
        {
            writeH(1064);
            writeH(0);
            writeC((byte)Rewards.Count);
            for (int i = 0; i < Rewards.Count; i++)
            {
                ItemsModel Item = Rewards[i];
                writeD(Item._id);
                writeD((int)Item._count);
            }
            writeC((byte)Index);
            writeD(CouponId);
        }
    }
}