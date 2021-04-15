using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";

        public static string ProductNameInvalid = "Ürün ismi Geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string CarRented = "Araç kiralandı";
        public static string CarRentError = "Araç kirada";

        public static string ImageAdded = "Resim eklendi";

        public static string MaxImageError = "Bir araç en fazla beş resme sahip olabilri.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
    }
}
