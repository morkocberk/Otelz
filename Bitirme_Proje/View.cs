 <div class="panel panel-default">
          <div class="panel-heading">
               <h4>Duyurular ve A��klamalar</h4>
          </div>
          <div class="panel-body">
              @if (ViewBag.RolEksik != null)
              {
                  <h4 style="color:red">@ViewBag.RolEksik</h4>
              }
                                <p>
                                    Y�netim sistemine ho�geldiniz.                                    
                                </p>
                                <p>
                                    Duyuru ekleme/d�zenleme i�lemi esnas�nda Vize/Final Durumu kutucu�unu i�aretlemek aktif olan b�t�n duyurular�n <b>g�r�nt�lenmesini engelleyip</b>, sadece Vize/Final Durumu "Evet" olan duyurular�n <b>g�r�nmesine</b> sebebiyet verir.
                                </p>
                                <p>
                                    Program d�zeni sekmesinden ders programlar�n�n g�sterilmesini <b>istemedi�iniz</b> tarihleri girerek, uygulamada girilen tarihler aras�nda ders program� g�sterimini engelleyebilirsiniz.
                                </p>
           </div>         
     </div>
@if (Roles.GetRolesForUser().Length > 1)
{
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Sahip Oldu�unuz Roller</h4>
        </div>
        <div class="panel-body">
            <p>L�tfen i�lem yapmadan �nce <b>rol se�iniz</b>. Aksi halde varsay�lan rol�n�zle i�lem yap�lacakt�r!</p>            
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
                <button type="button" class="close GlobalModalBoxClose" data-dismiss="modal" aria-hidden="true">�</button>
                <h4 class="modal-title">Uyar�</h4>
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
                    if (veri != "Kullan�c� bu role atanmam��!")
                    $("#roldurum").html("�uanki rol�n�z: " +roladi);
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