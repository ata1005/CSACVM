var imagesloader;

$(document).ready(function () {
    imagesloader = $('[data-type=imagesloader]').imagesloader({
        maxfiles: 1, minSelect: 1
    });
});


$('input[type=file]').change(function () {
    debugger;
    var idColumna = "#colImagen";
    var idDiv = "#divFoto";
    var divImagen = "";
    if (this.files && this.files[0]) {
        getBase64(this.files[0]).then(
            data => {
                $(idDiv).removeClass("d-flex");
                $(idDiv).addClass("d-none");
                divImagen = '<div class="divFotoNoBorder foto-message d-flex justify-content-center " id="divFoto">';
                divImagen = divImagen + '<label for="files" data-type="imagesloader"><img class="tamImagen" src="' + data + '"></label><input type="file" id="files" name="fotoPerfil" accept=".jpg,.jpeg,.png"/></div>';
                $(idColumna).append(divImagen);
            }
        );
    }
});

function getBase64(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}

function CargarFotos() {
    debugger;
    var files = imagesloader.data('format.imagesloader').AttachmentArray;
    var il = imagesloader.data('format.imagesloader');
    var datosform = new FormData($("#formPerfil")[0]);
    for (var i = 0; i < files.length; i++) {
        datosform.append("fotoPerfil", files[i].File);
    }

    $.ajax({
        type: "POST",
        url: "/Login/GuardarPerfil",
        async: true,
        data: datosform,
        contentType: false,
        processData: false,
        success: function (response) {

        }
    });
}