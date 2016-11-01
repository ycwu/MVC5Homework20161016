using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework20161016.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<客戶資料> Filter(string sSearch, string sType)
        {
            var data = this.All().Where(c => c.是否已刪除 == false);
            if (!string.IsNullOrEmpty(sSearch))
                data = data.Where(c => c.客戶名稱.Contains(sSearch));
            if (!string.IsNullOrEmpty(sType))
                data = data.Where(c => c.分類 == sType);
            
            return data.OrderByDescending(p => p.Id);
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}

}