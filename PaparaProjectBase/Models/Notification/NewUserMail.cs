using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBase.Models.Notification
{
    public static class NewUserMail
    {
        public static string Subject { get; } = "Kayıt Başarılı!";
        public static string Content { get; } = "Kullanıcı kaydınız başarıyla tamamlandı.";
    }
}
