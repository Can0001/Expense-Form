﻿using Core.Entities.Concrete;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
        //User--Kullanıcı
        public static string UserAdded = "Kullanıcı EKlendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdate = "Kullanıcı Güncellendi";
        public static string EmailExist="Mail Var";
        public static string UserListerd="Kullanıclar Listelendi";


        //Token--Auth
        public static string AccessTokenCreated= "Token Oluşturuldu";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError= "Parola Hatası";
        public static string SuccessfulLogin= "Başarılı Giriş";
        public static string UserRegistered="Kayıt Olundu";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
    }
}