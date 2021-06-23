using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string IncidentListed = "Incident listelendi.";
        public static string IncidentAdded = "Incident eklendi.";
        public static string IncidentUpdated = "Incident güncellendi.";
        public static string IncidentDeleted = "Incident silindi.";
        public static string dc_KategoriNameInvalid = "Geçersiz kategori ismi";
        public static string dc_ZamanInvalid = "Geçersiz zaman";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserListed = "Kullanıcı listelendi.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string UserRegistered="Kullanıcı giriş yaptı.";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Mevcut kullanıcı";
        public static string AccessTokenCreated="Giriş token oluşturuldu.";
    }
}
