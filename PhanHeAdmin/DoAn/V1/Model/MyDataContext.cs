using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1.Model
{
    public class MyDataContext : INotifyPropertyChanged // Thêm thư viện using System.ComponentModel;
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        List<Category> listCat;
        public List<Category> ListCat
        {
            get
            {
                return listCat;
            }

            set
            {
                if (value == listCat) return;
                listCat = value;
                OnPropertyChanged("ListCat");
            }
        }

        List<Product> listPro;
        public List<Product> ListPro
        {
            get
            {
                return listPro;
            }

            set
            {
                if (value == listPro) return;
                listPro = value;
                OnPropertyChanged("ListPro");
            }
        }

        List<NhaSanXuat> listNSX;
        public List<NhaSanXuat> ListNSX
        {
            get
            {
                return listNSX;
            }

            set
            {
                if (value == listNSX) return;
                listNSX = value;
                OnPropertyChanged("ListNSX");
            }
        }

        List<Order> listOrder;
        public List<Order> ListOrder
        {
            get
            {
                return listOrder;
            }

            set
            {
                if (value == listOrder) return;
                listOrder = value;
                OnPropertyChanged("ListOrder");
            }
        }

        List<User> listUser;
        public List<User> ListUser
        {
            get
            {
                return listUser;
            }

            set
            {
                if (value == listUser) return;
                listUser = value;
                OnPropertyChanged("ListUser");
            }
        }

        List<Order> listLichSuMuaHang;
        public List<Order> ListLichSuMuaHang
        {
            get
            {
                return listLichSuMuaHang;
            }

            set
            {
                if (value == listLichSuMuaHang) return;
                listLichSuMuaHang = value;
                OnPropertyChanged("ListLichSuMuaHang");
            }
        }


    }
}