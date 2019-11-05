using System;

namespace NuBot.Core.UserAccounts
{
    public class UserAccount
    {
        public ulong ID { get; set; }
        public ulong XP { get; set; }

        public uint LevelNumber
        {
            get
            {
                return (uint)Math.Sqrt(XP / 50);
            }
        }
    }
}