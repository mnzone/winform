using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Str
    {
        public static string rand(int count)
        {
            string str = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+";
            Random r = new Random();
            string result = string.Empty;

            //生成一个8位长的随机字符，具体长度可以自己更改
            for (int i = 0; i < count; i++)
            {
                int m = r.Next(0, 75);//这里下界是0，随机数可以取到，上界应该是75，因为随机数取不到上界，也就是最大74，符合我们的题意
                string s = str.Substring(m, 1);
                result += s;
            }

            return result;
        }
    }
}
