using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V1.Model;

namespace V1.Page
{
    public sealed class PageListProduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        List<Category> cats;
        public List<Category> Cats
        {
            get { return cats; }
            set
            {
                if (value == cats)
                {
                    return;
                }
                cats = value;
                OnPropertyChanged("Cats");
            }
        }
        List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (value == products)
                {
                    return;
                }
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public static int PageSize = 5;
        int curPage;
        public int CurPage
        {
            get { return curPage; }
            set
            {
                if (value == curPage)
                {
                    return;
                }
                curPage = value;
                OnPropertyChanged("CurPage");
            }
        }
        int totalPage;
        public int TotalPage
        {
            get { return totalPage; }
            set
            {
                if (value == totalPage)
                {
                    return;
                }
                totalPage = value;
                OnPropertyChanged("TotalPage");
            }
        }
    }
}
