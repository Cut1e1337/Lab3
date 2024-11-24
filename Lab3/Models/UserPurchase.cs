using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserPurchase
    {
        public int UserPurchaseID { get; set; }  // Первинний ключ
        public string UserLogin { get; set; }    // Логін користувача
        public int ApplicationID { get; set; }   // Ідентифікатор програми

        // Навігаційні властивості
        public Application Application { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
