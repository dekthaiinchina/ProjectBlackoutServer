using ProjectBlackout.Battle.Data.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjectBlackout.Battle.Data
{
    public class AllUtils
    {
        public static string gen5(string text)
        {
            using (var hmacMD5 = new HMACMD5(Encoding.UTF8.GetBytes("/x!a@r-$r%an¨.&e&+f*f(f(a)")))
            {
                byte[] data = hmacMD5.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static float GetDuration(DateTime date)
        {
            return (float)((DateTime.Now - date).TotalSeconds);
        }

        public static int getIdStatics(int id, int type)
        {
            if (type == 1)
            {
                return id / 100000; // Item Class
            }
            else if (type == 2)
            {
                return (id % 100000) / 1000; // Class Type
            }
            else if (type == 3)
            {
                return id % 1000; // Number
            }
            else if (type == 4)
            {
                return id % 10000000 / 100000;
            }
            return 0;
        }

        public static int CreateItemId(int ItemClass, int ClassType, int Number)
        {
            return (ItemClass * 100000) + (ClassType * 1000) + Number;
        }

        public static int ItemClass(CLASS_TYPE cw)
        {
            int valor = 1;
            if (cw == CLASS_TYPE.Assault)
            {
                valor = 1;
            }
            else if (cw == CLASS_TYPE.SMG || cw == CLASS_TYPE.DualSMG)
            {
                valor = 1;
            }
            else if (cw == CLASS_TYPE.Sniper)
            {
                valor = 1;
            }
            else if (cw == CLASS_TYPE.Shotgun || cw == CLASS_TYPE.DualShotgun)
            {
                valor = 1;
            }
            else if (cw == CLASS_TYPE.MG)
            {
                valor = 1;
            }
            else if (cw == CLASS_TYPE.HandGun || cw == CLASS_TYPE.DualHandGun || cw == CLASS_TYPE.CIC)
            {
                valor = 2;
            }
            else if (cw == CLASS_TYPE.Knife || cw == CLASS_TYPE.DualKnife || cw == CLASS_TYPE.Knuckle)
            {
                valor = 3;
            }
            else if (cw == CLASS_TYPE.Throwing)
            {
                valor = 4;
            }
            else if (cw == CLASS_TYPE.Item)
            {
                valor = 5;
            }
            else if (cw == CLASS_TYPE.Dino)
            {
                valor = 0;
            }
            return valor;
        }

        public static OBJECT_TYPE getHitType(uint info)
        {
            return (OBJECT_TYPE)(info & 3); //Max=4
        }

        public static int getHitWho(uint info)
        {
            return (int)((info >> 2) & 511); //Max=512
        }

        public static int getHitPart(uint info)
        {
            return (int)((info >> 11) & 63); //>> 11 & 63 Max=64
        }

        public static ushort getHitDamageBot(uint info) //Modo BOT
        {
            return (ushort)(info >> 20); //(Max=4096)
        }

        public static ushort getHitDamageNormal(uint info) //32768 e 65536
        {
            return (ushort)(info >> 21); //(Max=4096)
        }

        public static int getHitHelmet(uint info)
        {
            return (int)((info >> 17) & 7); //Max=8
        }

        public static int GetRoomInfo(uint UniqueRoomId, int type)
        {
            if (type == 0)
            {
                return (int)(UniqueRoomId & 0xfff);
            }
            else if (type == 1)
            {
                return (int)((UniqueRoomId >> 12) & 0xff);
            }
            else if (type == 2)
            {
                return (int)((UniqueRoomId >> 20) & 0xfff);
            }
            return 0;
        }

        public static int GetSeedInfo(uint Seed, int type)
        {
            if (type == 0)
            {
                return (int)(Seed & 0xfff);
            }
            else if (type == 1)
            {
                return (int)((Seed >> 12) & 0xff);
            }
            else if (type == 2)
            {
                return (int)((Seed >> 20) & 0xfff);
            }
            return 0;
        }

        public static byte[] Encrypt(byte[] data, int shift)
        {
            byte[] result = new byte[data.Length];
            Buffer.BlockCopy(data, 0, result, 0, result.Length);
            int length = result.Length;
            byte first = result[0];
            byte current;
            for (int i = 0; i < length; i++)
            {
                current = i >= (length - 1) ? first : result[i + 1];
                result[i] = (byte)(current >> (8 - shift) | (result[i] << shift));
            }
            return result;
        }

        public static byte[] Decrypt(byte[] data, int shift)
        {
            try
            {
                byte[] result = new byte[data.Length];
                Buffer.BlockCopy(data, 0, result, 0, result.Length);
                int length = result.Length;
                byte last = result[length - 1];
                byte current;
                for (int i = length - 1; (i & 0x80000000) == 0; i--)
                {
                    current = i <= 0 ? last : result[i - 1];
                    result[i] = (byte)(current << (8 - shift) | result[i] >> shift);
                }
                return result;
            }
            catch
            {
                Logger.warning(BitConverter.ToString(data));
                return new byte[0];
            }
        }

        public static int Percentage(int total, int percent)
        {
            return total * percent / 100;
        }
        public static float Percentage(float total, int percent)
        {
            return total * percent / 100;
        }
    }
}