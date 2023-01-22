using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Category
    {
        //Property Tanımlamak
        //Erişim belirleyici türü -Değişken türü- isim {get;set;}
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        //Category Blog İlişkisi
        public List<Blog> Blog { get; set; }
    }
}
