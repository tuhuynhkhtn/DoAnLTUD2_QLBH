using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace V1.Model
{
    public class Cart : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public IList<CartItem> Items { get; set; }
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public int TotalQuantity1()
        {
            return Items.Sum(i => i.Quantity);
        }

        public int TotalQuantity
        {
            get
            {
                return Items.Sum(i => i.Quantity);
            }
        }

        public void AddItem(int proId, int quantity = 1)
        {
            using (var dc = new QLBH1Entities())
            {
                var pro = dc.Products.Where(p => p.ProID == proId).FirstOrDefault();
                if (pro != null)
                {
                    var ci = Items.Where(i => i.Products.ProID == proId).FirstOrDefault();
                    if (ci == null)
                    {
                        Items.Add(new CartItem { Products = pro, Quantity = quantity });
                    }
                    else
                    {
                        ci.Quantity += quantity;
                    }
                    dc.SaveChanges();
                }
            }
        }

        public void Remove(int pId)
        {
            var ci = Items.Where(i => i.Products.ProID == pId).FirstOrDefault();
            if (ci != null)
            {
                Items.Remove(ci);
            }
        }

        public void Remove1(int pId)
        {
            var ci = Items.Where(i => i.Products.ProID == pId).FirstOrDefault();
            if (ci != null)
            {
                Items.Remove(ci);
            }
        }

        public void Update(int pId, int quantity)
        {
            var ci = Items.Where(i => i.Products.ProID == pId).FirstOrDefault();
            if (ci != null)
            {
                ci.Quantity = quantity;
            }
        }

        public void Checkout()
        {
            Items.Clear();
        }

        //Validation
        private static string rgNumber = @"^[0-9- ]\d*$";
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();

        private string quantity;
        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private string proID;

        public string ProID
        {
            get { return proID; }
            set { proID = value; }
        }
        

        private void Validate(string name)
        {
            Task.Run(() => DataValidation(name));
        }

        private void DataValidation(string name)
        {
            //Validate Name property
            switch (name)
            {
                case "Quantity":
                    List<string> listErrorsName;
                    if (propErrors.TryGetValue(Quantity, out listErrorsName) == false)
                    {
                        listErrorsName = new List<string>();
                    }
                    else
                    {
                        listErrorsName.Clear();
                    }

                    if (string.IsNullOrEmpty(Quantity))
                    {
                        listErrorsName.Add("Nhập số lượng mua!");
                    }

                    else
                    {
                        int q;
                        if (!Regex.IsMatch(Quantity, rgNumber))
                        {
                            listErrorsName.Add("Nhập số!");
                        }
                        else
                        {
                            q = int.Parse(Quantity);
                            if (q < 0)
                            {
                                listErrorsName.Add("Nhập số dương!");
                            }
                            else if (q <= 0)
                            {
                                listErrorsName.Add(" > 0 sản phẩm");
                            }
                            else if (q > 20)
                            {
                                listErrorsName.Add(" <= 20 sản phẩm");
                            }
                        }
                    }

                    if (listErrorsName.Count > 0)
                    {
                        propErrors["Quantity"] = listErrorsName;
                        OnPropertyErrorsChanged("Quantity");
                    }
                    else
                    {
                        propErrors["Quantity"].Clear();
                        OnPropertyErrorsChanged("Quantity");
                    }
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnPropertyErrorsChanged(string p)
        {
            if (ErrorsChanged != null)
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(p));
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            List<string> errors = new List<string>();
            if (propertyName != null)
            {
                propErrors.TryGetValue(propertyName, out errors);
                return errors;
            }

            else
                return null;
        }

        public bool HasErrors
        {
            get
            {
                try
                {
                    var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                    if (propErrorsCount != null)
                        return true;
                    else
                        return false;
                }
                catch { }
                return true;
            }
        }

        # endregion

        #region INotifyPropertyChanged

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
                Validate(name);
            }
        }

        #endregion
        //End Validation
    }
    public class CartItem
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}
