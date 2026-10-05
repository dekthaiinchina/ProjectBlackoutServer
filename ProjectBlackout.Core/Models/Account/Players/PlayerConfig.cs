namespace ProjectBlackout.Core.Models.Account.Players
{
    public class PlayerConfig
    {
        public int 
            sight,
            audio1 = 100,
            audio2 = 60,
            sensibilidade = 50,
            fov = 70,
            blood = 1,
            hand,
            audio_enable = 7,
            config = 55,
            mouse_invertido,
            msgConvite,
            chatSussurro,
            macro = 31;

        public string
            macro_1 = "",
            macro_2 = "",
            macro_3 = "",
            macro_4 = "",
            macro_5 = "";

        public byte[] keys = new byte[235];
    }
}