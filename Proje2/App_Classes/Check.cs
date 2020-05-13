
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BakanlikSinavProje.App_Classes
{
    public class IzinKontrol
    {
        BakanlikSinav db = new BakanlikSinav();
        Guid RoleId;
        
        public IzinKontrol()
        {
            RoleId = db.aspnet_Roles.FirstOrDefault(x => x.RoleName == "Moderator").RoleId;
        }        
        
        public bool RolGiris()
        {
            return false;
        }

        public bool AnasayfaGiris()
        {
            if (db.Role_Permission.FirstOrDefault(x => x.RoleId == RoleId).AnaSayfaGorsun == true) return true;
            else return false;
        }

        public bool KullaniciGorsun()
        {
            if (db.Role_Permission.FirstOrDefault(x => x.RoleId == RoleId).KullaniciGorsun == true) return true;
            else return false;
        }

        

    }
}