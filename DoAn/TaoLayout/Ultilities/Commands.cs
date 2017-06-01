using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLayout.Commands;

namespace TaoLayout.Ultilities
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
