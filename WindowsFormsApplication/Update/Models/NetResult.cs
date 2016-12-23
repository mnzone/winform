using System;

namespace Update.Models
{
    public class NetResult
    {
        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private String msg;

        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private int errCode;

        public int ErrCode
        {
            get { return errCode; }
            set { errCode = value; }
        }
        private Object data;

        public Object Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
