using System;

namespace DataSynchronization
{
    public class SynModel
    {
        private int id;
        private String command;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }
    }
}