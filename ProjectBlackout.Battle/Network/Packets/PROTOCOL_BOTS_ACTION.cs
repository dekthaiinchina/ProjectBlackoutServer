using ProjectBlackout.Battle.Data;
using ProjectBlackout.Battle.Data.Enums;
using ProjectBlackout.Battle.Data.Models;
using ProjectBlackout.Battle.Network.Actions.SubHead;
using System;
using System.IO;

namespace ProjectBlackout.Battle.Network.Packets
{
    public class PROTOCOL_BOTS_ACTION
    {
        public static byte[] getBaseData(byte[] data)
        {
            ReceivePacket p = new ReceivePacket(data);
            using (SendPacket s = new SendPacket())
            {
                s.writeT(p.readT());
                for (int i = 0; i < 16; i++)
                {
                    ActionModel ac = new ActionModel();
                    try
                    {
                        bool exception;
                        ac.SubHead = (UDP_SUB_HEAD)p.readC(out exception);
                        if (exception)
                        {
                            break;
                        }
                        ac.Slot = p.readUH();
                        ac.Length = p.readUH();
                        if (ac.Length == 65535)
                        {
                            break;
                        }
                        s.writeC((byte)ac.SubHead);
                        s.writeH(ac.Slot);
                        s.writeH(ac.Length);
                        if (ac.SubHead == UDP_SUB_HEAD.GRENADE)
                        {
                            GrenadeSync.WriteInfo(s, p);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.DROPEDWEAPON)
                        {
                            DropedWeapon.WriteInfo(s, p);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.OBJECT_STATIC)
                        {
                            ObjectStatic.WriteInfo(s, p);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.OBJECT_ANIM)
                        {
                            ObjectAnim.WriteInfo(s, p);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.STAGEINFO_OBJ_STATIC)
                        {
                            StageInfoObjStatic.WriteInfo(s, p, false);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.STAGEINFO_OBJ_ANIM)
                        {
                            StageObjAnim.WriteInfo(s, p);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.CONTROLED_OBJECT)
                        {
                            ControledObj.WriteInfo(s, p, false);
                        }
                        else if (ac.SubHead == UDP_SUB_HEAD.USER || ac.SubHead == UDP_SUB_HEAD.STAGEINFO_CHARA)
                        {
                            ac.Flag = (UDP_GAME_EVENTS)p.readUD();
                            ac.Data = p.readB(ac.Length - 9);
                            s.writeD((uint)ac.Flag);
                            s.writeB(ac.Data);
                            if (ac.Data.Length == 0 && (uint)ac.Flag != 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Logger.warning("[New User Packet Type: '" + ac.SubHead + "' or '" + (int)ac.SubHead + "']: " + BitConverter.ToString(data));
                            throw new Exception("Unknown Action Type[2]");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.warning("Buffer: " + BitConverter.ToString(data));
                        Logger.warning(ex.ToString());
                        s.mstream = new MemoryStream();
                        break;
                    }
                }
                return s.mstream.ToArray();
            }
        }

        public static byte[] getCode(byte[] data, DateTime time, int round, int slot)
        {
            using (SendPacket s = new SendPacket())
            {
                byte[] actions = getBaseData(data);
                s.writeC(132);
                s.writeC((byte)slot);
                s.writeT(AllUtils.GetDuration(time));
                s.writeC((byte)round);
                s.writeH((ushort)(13 + actions.Length));
                s.writeD(0);
                s.writeB(AllUtils.Encrypt(actions, (13 + actions.Length) % 6 + 1));
                return s.mstream.ToArray();
            }
        }
    }
}