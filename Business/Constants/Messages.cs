using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MovieAdded = "Film Eklendi";
        public static string MovieNameInvalid = "Film ismi geçersiz";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string MovieListed="Ürünler Listelendi";
        public static string MovieImdbPointInvalid = "Geçerli bir imdb puanı giriniz.";
        public static string MovieCountofGenreError = "aynı türde 10'dan fazla film olamaz.";
        public static string MovieExistError = "Film mevcut";
        public static string GenreLimitExceded = "Tür limiti aşıldı";
    }
}
