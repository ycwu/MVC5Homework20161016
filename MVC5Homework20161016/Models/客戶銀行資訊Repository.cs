using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework20161016.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{

	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}