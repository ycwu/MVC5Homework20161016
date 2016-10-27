namespace MVC5Homework20161016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (validationContext.Items.Count > 0)
            //{
                客戶資料Entities db = new 客戶資料Entities();
                客戶聯絡人 contact1 = (客戶聯絡人)validationContext.ObjectInstance;
                var e = db.客戶聯絡人.SqlQuery("SELECT * FROM 客戶聯絡人 WHERE Email=@p0", this.Email).GetEnumerator();
                while (e.MoveNext())
                {
                    var value = e.Current;
                    if (value.Email != "")
                        yield return new ValidationResult("Email已重覆", new string[] { "Email" });
                }
            //}   
            yield break;
        }

        static void Write(IEnumerator<客戶聯絡人> e)
        {
            while (e.MoveNext())
            {
                var value = e.Current;
                Console.WriteLine(value);
            }
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage ="欄位格式錯誤")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [RegularExpression(@"\d{3}-\d{6}", ErrorMessage = "欄位格式錯誤")]
        public string 電話 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
