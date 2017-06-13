using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using V1.Model;
using V1.Ultilities;

namespace V1.UC
{
    /// <summary>
    /// Interaction logic for UCDetail.xaml
    /// </summary>
    public partial class UCDetail : UserControl
    {
        public UCDetail()
        {
            InitializeComponent();
        }

        public UCDetail(int proID)
        {
            InitializeComponent();
            txtQuantity.Text = "1";
            using (var dc = new QLBH1Entities())
            {
                var pro = dc.Products.Where(p => p.ProID == proID).FirstOrDefault();

                ProInfo proInfo = new ProInfo();
                proInfo.ProID = pro.ProID;
                proInfo.ProName = pro.ProName;
                proInfo.Price = pro.Price;
                proInfo.SoLuotXem = (int)pro.SoLuotXem;
                proInfo.SoLuongBan = 1;
                proInfo.XuatXu = pro.XuatXu;

                var NhaSX = dc.NhaSanXuats.Where(n => n.IDNhaSanXuat == pro.IDNhaSanXuat).FirstOrDefault();
                proInfo.NhaSanXuat = NhaSX.TenNhaSanXuat;

                if (pro.Loai == 1)
                {
                    proInfo.Loai = "Cao cấp";
                }
                if (pro.Loai == 2)
                {
                    proInfo.Loai = "Trung cấp";
                }
                else 
                {
                    proInfo.Loai = "Thường";
                }

                HtmlToText html = new HtmlToText();
                string strFullDes = html.Convert(pro.FullDes);
                proInfo.FullDes = strFullDes;

                DataContext = proInfo;

                //Cung loai
                lvProductTogether.ItemsSource = dc.Products
                    .Where(p => p.ProID != proID && p.Loai == pro.Loai)
                    .Take(5)
                    .ToList();

                //Cung nha san xuat
                lvProducer.ItemsSource = dc.Products
                    .Where(p => p.ProID != pro.ProID && p.IDNhaSanXuat == pro.IDNhaSanXuat)
                    .Take(5)
                    .ToList();
            }
        }
    }
}
