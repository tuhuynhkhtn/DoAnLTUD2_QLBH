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

        //Admin
        public static ButtonAddCatCmd ButtonAddCatCmd { get; set; }
        public static ButtonDeleteCatCmd ButtonDeleteCatCmd { get; set; }
        public static ButtonUpdateCatCmd ButtonUpdateCatCmd { get; set; }
        public static ButtonAddNSXCmd ButtonAddNSXCmd { get; set; }
        public static ButtonDeleteNSXCmd ButtonDeleteNSXCmd { get; set; }
        public static ButtonUpdateNSXCmd ButtonUpdateNSXCmd { get; set; }
        public static ButtonOrderDaGiaoCmd ButtonOrderDaGiaoCmd { get; set; }
        public static ButtonOrderChuaGiaoCmd ButtonOrderChuaGiaoCmd { get; set; }

        static Commands()
        {
            ButtonLeftCatCmd = new ButtonLeftCatCmd();
            ButtonLeftProCmd = new ButtonLeftProCmd();

            ButtonBuyListCmd = new ButtonBuyListCmd();
            ButtonBuyDetailCmd = new ButtonBuyDetailCmd();

            ButtonDetailCmd = new ButtonDetailCmd();

            ButtonAddCatCmd = new ButtonAddCatCmd();
            ButtonDeleteCatCmd = new ButtonDeleteCatCmd();
            ButtonUpdateCatCmd = new ButtonUpdateCatCmd();
            ButtonAddNSXCmd = new ButtonAddNSXCmd();
            ButtonDeleteNSXCmd = new ButtonDeleteNSXCmd();
            ButtonUpdateNSXCmd = new ButtonUpdateNSXCmd();
            ButtonOrderDaGiaoCmd = new ButtonOrderDaGiaoCmd();
            ButtonOrderChuaGiaoCmd = new ButtonOrderChuaGiaoCmd();
        }
    }
}
