using System.Windows.Forms;

namespace MemberCard
{
    public class FrmBase : Form
    {
        protected bool isKeyword(char keyChar)
        {
            bool flag = false;

            int key = (int)keyChar;
            switch (key)
            {
                case 13:
                    flag = true;
                    break;
                case 8:
                    flag = true;
                    break;
                case 27:
                    flag = true;
                    break;
            }

            return flag;
        }
    }
}