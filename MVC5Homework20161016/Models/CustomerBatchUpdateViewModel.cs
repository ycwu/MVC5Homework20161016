using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Homework20161016.Models
{
    public class CustomerBatchUpdateViewModel
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        public string 職稱 { get; set; }
        public string 姓名 { get; set; }
        public string Email { get; set; }
        public string 手機 { get; set; }
        public string 電話 { get; set; }
        public bool 是否已刪除 { get; set; }

        //public virtual 客戶資料 客戶資料 { get; set; }
    }
}