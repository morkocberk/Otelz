		[HttpPost]
        [ValidateAntiForgeryToken]
        [NoAccessforAuthenticated]
        public ActionResult SifremiUnuttum(string KullaniciAdi)
        {            
            Regex emailR = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool telefon;
            if(KullaniciAdi == null &&  KullaniciAdi == "")
            {
                ViewBag.Sonuc = false;
                ViewBag.Error = "Girilen bilgiler hatal�.";
                return View();
            }
            else if (emailR.IsMatch(KullaniciAdi)) //email ile e�le�irse
            {
                telefon = false;
            }
            else
            {
                telefon = true;
            }
            aspnet_Users eksper = new aspnet_Users();
            if (telefon)
            {
                string phone = KullaniciAdi;
                if (phone.StartsWith("0"))
                {
                    phone = "+9" + phone;
                }
                else if (phone.StartsWith("5"))
                {
                    phone = "+90" + phone;
                }
                eksper = db.aspnet_Users.FirstOrDefault(x => x.Eksperler.Telefon == phone);
            }
            else
            {
                eksper = db.aspnet_Users.FirstOrDefault(x => x.aspnet_Membership.Email == KullaniciAdi);
            }

            if (eksper != null)
            {                
                Guid g = Guid.NewGuid();             
                string title = "e-Ekspertiz - �ifre S�f�rlama";
                string body = "Yeni �ifre olu�turmak i�in l�tfen a�a��daki tek kullan�ml�k linke t�klay�n�z.<br/>" + Url.Action("SifreSifirla", "Home", new { key = g, id = eksper.UserId }, Request.Url.Scheme);                    
                string Email = eksper.aspnet_Membership.Email;
                bool sonuc = SendEmail(Email, body, title);                
                
                if (sonuc)
                { 
                    if(SifreRes != null && SifreRes.Any(x=>x.UserId == eksper.UserId))
                    {
                        SifreRes.Remove(SifreRes.FirstOrDefault(x => x.UserId == eksper.UserId));
                    }
                    SifreRes res = new SifreRes();
                    res.Key = g;
                    res.UserId = eksper.UserId;
                    res.Used = false;
                    SifreRes.Add(res);
                    ViewBag.Sonuc = true;
                }

            }
            else
            {
                ViewBag.Sonuc = false;
                ViewBag.Kullanici = KullaniciAdi;                
                ViewBag.Error = "Girilen bilgiler do�rulanamad�. L�tfen girdi�iniz bilgileri kontrol edip tekrar deneyiniz.";
            }
            return View();
        }