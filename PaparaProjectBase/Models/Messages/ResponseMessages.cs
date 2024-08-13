using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBase.Models.Messages
{
    public class ResponseMessages
    {
        public static string NotFound = "Bulunamadı!";
        public static string CategoryHasProducts = "Bu kategoriye ait ürünler var. Kategori silinemez!";
        public static string InvalidUserInformation = "Geçersiz kullanıcı bilgileri. Kullanıcı adı ve şifreyi kontorl edin.";
        public static string InsufficientFund = "Yetersiz bakiye!";
    }
}
