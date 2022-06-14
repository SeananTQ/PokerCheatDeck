using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeananTools
{
    static class StringExtensionClass
    {
        public static char splitChar = '_';
        //用下划线将字符串分割成段，得到段数
        public static int SplitLength(this string str)
        {
            string[] strArray = str.Split(splitChar);
            return strArray.Length;
        }

        //用下划线分割字符串，得到数组，根据参数返回第N段字符
        public static string GetSplitNString(this string str, int n)
        {
            string[] strArray = str.Split(splitChar);
            return strArray[n];
        }

        //用下划线分割字符串，得到数组，返回前N段内容
        public static string SubSplitNString(this string str, int n)
        {
            string[] strArray = str.Split(splitChar);
            string tempString = "";
            for (int i = 0; i < n; i++)
            {
                if (i < strArray.Length)
                {
                    tempString = tempString+"_"+ strArray[i];
                }
                else
                {
                    break;
                }    
            }
            return tempString;
        }

        //判断字符串中大部分的字符是否为字母
        public static bool IsMostLetter(this string str)
        {
            int count = 0;
            bool isMostLetter = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    count++;
                }
            }
            if (count*2 < str.Length)
            {
                isMostLetter = false;
            }
            return isMostLetter;
        }

    }
}
