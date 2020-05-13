[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SlideDuzenle(Duyurular slide, HttpPostedFileBase file)
        {
            string rol;
            if (Session["SecilenRol"] != null)
            {
                rol = Session["SecilenRol"].ToString();
            }
            else
            {
                rol = Roles.GetRolesForUser()[0]; //varsayýlan ilk rolü alýr
            }

            if (slide.GosterimSuresi <= 0 || slide.GosterimSuresi == null)
            {
                TempData["shortMessage"] = "Gösterim süresi 0 veya boþ olamaz!";
                return RedirectToAction("SlideDuzenle", "Admin", new { @SlideID = slide.ID });
            }
            if (slide.BaslangicTarih > slide.BitisTarih)
            {
                TempData["shortMessage"] = "Baþlangýç tarihi bitiþ tarihinden daha ileride olamaz!";
                return RedirectToAction("SlideDuzenle", "Admin", new { @SlideID = slide.ID });
            }
            try
            {
                using (Bitirme context = new Bitirme())
                {
                    var _slideDuzenle = context.Duyurular.Where(x => x.ID == slide.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slideDuzenle.Foto = memoryStream.ToArray();
                    }
                    _slideDuzenle.GosterimSuresi = slide.GosterimSuresi;
                    _slideDuzenle.BaslangicTarih = slide.BaslangicTarih;
                    _slideDuzenle.BitisTarih = slide.BitisTarih;
                    _slideDuzenle.Vize_Final = slide.Vize_Final;
                    _slideDuzenle.Rol = rol;
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluþtu " + ex.Message);
            }

        }