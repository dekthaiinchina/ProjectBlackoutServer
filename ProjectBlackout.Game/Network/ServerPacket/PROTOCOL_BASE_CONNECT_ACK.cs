using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using ProjectBlackout.Core;
using ProjectBlackout.Core.Network;
using ProjectBlackout.Game.Data.Configs;
using ProjectBlackout.Game.Data.Model;
using ProjectBlackout.Game.Data.Xml;
using System;
using System.Net;

namespace ProjectBlackout.Game.Network.ServerPacket
{
    public class PROTOCOL_BASE_CONNECT_ACK : SendPacket
    {
        private IPAddress Ip;
        private uint SessionId;
        private ushort SessionSeed;

        public PROTOCOL_BASE_CONNECT_ACK(GameClient Client)
        {
            SessionId = Client.SessionId;
            SessionSeed = Client.SessionSeed;
            Ip = Client.GetAddress();
        }

        public override void write()
        {
            CheckIp(Ip);
            writeH(514);
            writeH(0);
            writeC(10);
            for (int i = 0; i < 10; i++)
                writeC(0);

            writeH(6);
            writeH(4);
            writeD(unchecked((short)319394958)); // shortkey
            writeC(3);
            writeH(68);
            writeD(SessionId);
        }

        public void CheckIp(IPAddress Ip)
        {
            Logger.LogProblems(Ip.ToString(), "Ip/Game");
        }

        public static AsymmetricCipherKeyPair GeneratePair()
        {
            CryptoApiRandomGenerator RandomGenerator = new CryptoApiRandomGenerator();
            SecureRandom Secure = new SecureRandom(RandomGenerator);
            RsaKeyPairGenerator RSA = new RsaKeyPairGenerator();
            RSA.Init(new KeyGenerationParameters(Secure, 1024));
            AsymmetricCipherKeyPair Pair = RSA.GenerateKeyPair();
            return Pair;
        }
    }
}