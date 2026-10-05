using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Data.Models.Event;

namespace ProjectBlackout.Battle.Network.Actions.Event
{
    public class FireData
    {
        public static FireDataInfo ReadInfo(ActionModel Action, ReceivePacket Packet, bool Log)
        {
            FireDataInfo Info = new FireDataInfo
            {
                Effect = Packet.readC(),
                Part = Packet.readC(),
                Index = Packet.readH(),
                X = Packet.readUH(),
                Y = Packet.readUH(),
                Z = Packet.readUH(),
                Extensions = Packet.readC(),
                WeaponId = Packet.readD()
            };
            if (Log)
            {
                Logger.warning("[1] Effect: " + (Info.Effect >> 4) + "; Slot: " + (Info.Effect & 15));
                Logger.warning("[2] Slot: " + Action.Slot + " FireData: " + Info.Effect + ";" + Info.Part);
            }
            return Info;
        }

        public static void ReadInfo(ReceivePacket Packet)
        {
            Packet.Advance(15);
        }

        public static void WriteInfo(SendPacket Send, ActionModel Action, ReceivePacket Packet, bool Log)
        {
            FireDataInfo Info = ReadInfo(Action, Packet, Log);
            WriteInfo(Send, Info);
            Info = null;
        }

        public static void WriteInfo(SendPacket Send, FireDataInfo Info)
        {
            Send.writeC(Info.Effect);
            Send.writeC(Info.Part);
            Send.writeH(Info.Index);
            Send.writeH(Info.X);
            Send.writeH(Info.Y);
            Send.writeH(Info.Z);
            Send.writeC(Info.Extensions);
            Send.writeD(Info.WeaponId);
        }
    }
}