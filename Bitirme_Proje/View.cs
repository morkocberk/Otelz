 <div class="panel panel-default">
          <div class="panel-heading">
               <h4>Duyurular ve Açýklamalar</h4>
          </div>
          <div class="panel-body">
              @if (ViewBag.RolEksik != null)
              {
                  <h4 style="color:red">@ViewBag.RolEksik</h4>
              }
                                <p>
                                    Yönetim sistemine hoþgeldiniz.                                    
                                </p>
                                <p>
                                    Duyuru ekleme/düzenleme iþlemi esnasýnda Vize/Final Durumu kutucuðunu iþaretlemek aktif olan bütün duyurularýn <b>görüntülenmesini engelleyip</b>, sadece Vize/Final Durumu "Evet" olan duyurularýn <b>görünmesine</b> sebebiyet verir.
                                </p>
                                <p>
                                    Program düzeni sekmesinden ders programlarýnýn gösterilmesini <b>istemediðiniz</b> tarihleri girerek, uygulamada girilen tarihler arasýnda ders programý gösterimini engelleyebilirsiniz.
                                </p>
           </div>         
     </div>
@if (Roles.GetRolesForUser().Length > 1)
{
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Sahip Olduðunuz Roller</h4>
        </div>
        <div class="panel-body">
            <p>Lütfen iþlem yapmadan önce <b>rol seçiniz</b>. Aksi halde varsayýlan rolünüzle iþlem yapýlacaktýr!</p>            
            @foreach (string rol in Roles.GetRolesForUser())
            {                
                <p>Rol &#8594; <a class="rolsecim" data-toggle="modal" data-target="#SifreModalBox" name="@rol">@rol</a></p>
            }
        </div>
    </div>
}
<div id="SifreModalBox" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close GlobalModalBoxClose" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title">Uyarý</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="row" id="panel1">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-12"> 
                                    <p id="Uyari"></p>                                   
                                            <div class="input-group-sm">
                                                <button type="button" class="btn btn-success" id="SifreAl" data-dismiss="modal" aria-hidden="true">Tamam</button>
                                            </div> 
                                </div>
                            </div>
                        </div>
                    </div>                    
                </div>
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<script>
    $(document).ready(function () {
        $(".rolsecim").click(function () {
            var result = true;
            if(result){
                var roladi = $(this).attr("name");
            $.ajax({
                type: "GET",
                url: "/x/Rols",
                data: { RolAdi: roladi },
                success: function a(veri) {
                    $("#Uyari").html('');
                    $("#Uyari").html("&#10004; " + veri);
                    if (veri != "Kullanýcý bu role atanmamýþ!")
                    $("#roldurum").html("Þuanki rolünüz: " +roladi);
                },
                error: function b() {
                    $("#Uyari").html('');
                    $("#Uyari").html("&#10007; " + veri);
                }
            })
        }
        });
    });
</script>