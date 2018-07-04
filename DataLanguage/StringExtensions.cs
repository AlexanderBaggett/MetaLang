using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaLanguage
{
    public static class StringExtensions
    {
        public static bool StartsWithMulti(this String str,string [] Items)
        {
            for(int i =0; i < Items.Length; i++)
            {
               if( str.StartsWith(Items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CharPositionXIsOneOftheFollowing(this String str, char[] Items, int position)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (str[position] == Items[i] )
                {
                    return true;
                }
            }
            return false;
        }
        public static bool StringPositionXIsOneOftheFollowing(this String str, string[] Items, int position)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (str.Substring(position) == Items[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool EndsWithMulti(this String str, string[] Items, long position)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (str.EndsWith(Items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsOne(this String str, string[] Items)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (str.Contains(Items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsAll(this String str, string[] Items)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (str.Contains(Items[i])){}
                else { return false; }
            }
            return true;
        }

    }
}
