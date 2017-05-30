using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFQLBH.Commands;

namespace WPFQLBH.Ultilities
{
    public class Commands
    {
        public static LeftMenuCmd LeftMenuCmd { get; }

        static Commands()
        {
            LeftMenuCmd = new LeftMenuCmd();
        }
    }
}
