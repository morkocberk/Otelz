		[OzelUyeGiremez]
        public JsonResult IndirimKodu(string IndirimKodu) // 0 indirim bilgileri 1 uygulanan indirimin açýklamasý 2 odenecek tutar
        {
            string[] dizi = new string[3];            
            dizi[0] = "0 tl";            
            if (kodkullandi == 1)
            {                
                dizi[1] = "Zaten bir kod kullanmýþtýnýz!";
                return Json(dizi, JsonRequestBehavior.AllowGet);
            }
            MembershipUser u = Membership.GetUser();
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Username == u.UserName);
            var kullanici_kadro = kullanici.Kullanici_Kurum_Kadro.FirstOrDefault(y => y.UserID == kullanici.UserID);
            if (db.Indirim.Any(x => x.IndirimKodu == IndirimKodu && x.KadroId == kullanici_kadro.KadroId))
            {
                var indirim = db.Indirim.FirstOrDefault(x => x.IndirimKodu == IndirimKodu);
                if (db.Kullanici_Indirim.Any(x => x.IndirimKodu == IndirimKodu && x.UserId == kullanici.UserID))
                {
                    dizi[1] = "Bu kod daha önceden kullanýlmýþ!";
                    return Json(dizi, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    kodkullandi = 1;
                    indirimkodu = IndirimKodu;          
                    double ucret = Convert.ToDouble(db.Kadrolar.FirstOrDefault(x => x.KadroId == kullanici_kadro.KadroId).Ucret);
                    if (indirim.YuzdelikMi == true)
                    {
                        double aratoplam = (ucret * (double)indirim.IndirimMiktari / 100);
                        odenecektutar = ucret - aratoplam;                       
                        dizi[0] = aratoplam.ToString() + " tl";
                        dizi[1] = "Girdiðiniz indirim koduna ait toplam tutar üzerinden %" + indirim.IndirimMiktari + " indirim uygulanmýþtýr.";
                        dizi[2] = odenecektutar.ToString() + " tl";
                        return Json(dizi, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        odenecektutar = ucret - (double)indirim.IndirimMiktari;                        
                        dizi[0] = indirim.IndirimMiktari.ToString() + " tl";
                        dizi[1] = "Girdiðiniz indirim koduna ait toplam tutar üzerinden " + indirim.IndirimMiktari + " ? indirim uygulanmýþtýr.";
                        dizi[2] = odenecektutar.ToString() + " tl";
                        return Json(dizi, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                dizi[1] = "Girdiðiniz indirim kodu geçersiz!";
                return Json(dizi, JsonRequestBehavior.AllowGet);
            }
           
        }
		
		