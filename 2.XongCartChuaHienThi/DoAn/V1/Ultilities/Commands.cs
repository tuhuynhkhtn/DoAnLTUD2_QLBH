using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V1.Commands;

namespace V1.Ultilities
{
    public class Commands
    {

        //Categories
        public static ButtonLeftCatCmd ButtonLeftCatCmd { get; set; }

        //Producer
        public static ButtonLeftProCmd ButtonLeftProCmd { get; set; }

        public static ButtonBuyListCmd ButtonBuyListCmd { get; set; }
        public static ButtonBuyDetailCmd ButtonBuyDetailCmd { get; set; }


        public static ButtonDetailCmd ButtonDetailCmd { get; set; }

        static Commands()
        {
            ButtonLeftCatCmd = new ButtonLeftCatCmd();
            ButtonLeftProCmd = new ButtonLeftProCmd();

            ButtonBuyListCmd = new ButtonBuyListCmd();
            ButtonBuyDetailCmd = new ButtonBuyDetailCmd();

            ButtonDetailCmd = new ButtonDetailCmd();
        }
    }
}
