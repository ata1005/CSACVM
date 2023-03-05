﻿
function inicializarTablaCurriculums(cvs) {
    $("#tablaCurriculums").DataTable({
        data: cvs,
        orderCellsTop: true,
        paging: false,
        destroy: true,
        order: [2, "desc"],
        scrollX: true,
        columnDefs: [
            {
                targets: 0,
                title: "Id Curriculum",
                data: "idCurriculum",
                visible: false,
                searchable: false
            },
            {
                targets: 1,
                title: "Título del currículum",
                data: "titulo",
                width: "30%",
                visible: true,
                searchable: false
            },
            {
                targets: 2,
                title: "Fecha creación",
                data: "fechaCurriculum",
                type:'datetime-moment',
                width: "20%",
                visible: true,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    return moment(new Date(data).toString()).format('D/M/YYYY HH:mm');
                }
            },
            {
                targets: 3,
                title: "Editar",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:editarCurriculum(\'' + row.idCurriculum + '\');"><i class="fa-solid fa-pen fa-xl c-grey"></i></a>';
                }
            },
            {
                targets: 4,
                title: "Exportar PDF",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:exportarPDF(\'' + row.idCurriculum + '\');"><i class="fa-solid fa-file-pdf fa-xl c-grey"></i></a>';
                }
            },
            
        ],
        oLanguage: {
            sEmptyTable: "Sin Datos",
            sZeroRecords: "No existen registros",
            oPaginate: {
                sPrevious: "Anterior",
                sNext: "Siguiente"
            },
            sLengthMenu: "Mostrar _MENU_ registros",
            sLoadingRecords: "<i class='fa fa-hourglass-half'></i> Procesando"
        },
        sDom: '<l<t>p>'
    });

}

function crearCurriculum() {
    debugger;
    var divsCrearCV = "#divsCrearCV";
    var texto = $("#inputCrearCV").val()
    modal = $('#modalCrearCV')[0];
    $(modal).modal('toggle');
    modal.style.display = "block";
    divs = ('<div class="row-12 ms-3">');
    divs = divs + ('<div class="row-12">');
    divs = divs + ('<span><strong>Título:</strong></span></div>');
    divs = divs + ('<div class="row-12 mt-2 ms-1"><input class="form-control w-50" type="text" id="inputCrearCV"/></div>');
    divs = divs + ('</div>');
    divs = divs + ('<div class="row-12 mt-3 d-flex justify-content-end">');
    divs = divs + ('<button class="btn btn-success" onclick="confirmarCrearCV()">Confirmar</button>');
    divs = divs + ('</div">');
    $("#modalBody").children(divsCrearCV).append(divs);
}

function confirmarCrearCV() {
    debugger;
    
    $.ajax({
        type: "POST",
        url: "/Curriculum/NuevoCurriculum",
        data: {
            'titulo': $("#inputCrearCV").val()
        },
        async: true,
        success: function (response) {
            
        }
    });
}

function cerrarModal(nombreModal) {
    modalH = $("#" + nombreModal);
    modalH.modal('hide');
    $("#divsCrearCV").children().remove();
}

function editarCurriculum(idCurriculum) {
    window.location.href = "/Curriculum/RedirectCurriculum/?idCurriculum=" + idCurriculum;
}

// ZONA DE IMAGENES
var imagesloader;

$(document).ready(function () {
    imagesloader = $('[data-type=imagesloader]').imagesloader({
        maxfiles: 1, minSelect: 1
    });
});


$('input[type=file]').change(function () {
    debugger;
    var files = imagesloader.data('format.imagesloader').AttachmentArray;
    if (files.length < 1) {
        var idColumna = "#colImagenCV";
        var idDiv = "#divFotoCV";
        var divImagen = "";
        if (this.files && this.files[0]) {
            getBase64(this.files[0]).then(
                data => {
                    $(idDiv).removeClass("d-flex");
                    $(idDiv).addClass("d-none");
                    divImagen = '<div class="divFotoNoBorder foto-message d-flex justify-content-center " id="divFotoCV">';
                    divImagen = divImagen + '<label for="files" data-type="imagesloader"><img class="tamImagen" src="' + data + '"></label><input type="file" id="files" name="fotoCurriculum" accept=".jpg,.jpeg,.png"/></div>';
                    $(idColumna).append(divImagen);
                }
            );
        } 
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
    var datosform = new FormData($("#formCurriculum")[0]);
    for (var i = 0; i < files.length; i++) {
        datosform.append("fotoCurriculum", files[i].File);
    }

    $.ajax({
        type: "POST",
        url: "/Curriculum/GuardarCurriculum",
        async: true,
        data: datosform,
        contentType: false,
        processData: false,
        success: function (response) {

        }
    });
}



// INPUTS FORMACION
var contadorFormacion = 1;
var contadorMax = $(".formacionContainerClass").length;

function addFormacion() {
    var strNuevaFila = "";
    $("#btnAddFormacion").remove();
    debugger;
    contadorFormacion = document.getElementsByClassName("formacionContainerClass").length;
    contadorFormacion = $(".formacionContainerClass").length;
    contadorMax++;
    if (contadorFormacion == 1) {
        $(".btnRemove").removeAttr("disabled");
        $(".btnRemove").attr("onclick", "javascript: removeFormacion(1);");
    }
    contadorFormacion = contadorMax;
    
    
    strNuevaFila = '<div class="container formacionContainerClass" id="formacionContainer_' + contadorFormacion +'"><div class="row">'
    strNuevaFila = strNuevaFila + '<div class="col-4 pe-2"><label class="form-label fw-bold">Grado/Estudios:</label>';
    strNuevaFila = strNuevaFila + '<input class="form-control" placeholder="Grado" aria-required="true" name="gradoFormacion_' + contadorFormacion + '" id="gradoFormacion_' + contadorFormacion + '"/></div>';
    strNuevaFila = strNuevaFila + '<div class="col-4 pe-2"><label class="form-label fw-bold">Ubicación:</label>';
    strNuevaFila = strNuevaFila + '<input class="form-control" placeholder="Ubicación" aria-required="true" name="ubicacionFormacion_' + contadorFormacion + '" id="ubicacionFormacion_' + contadorFormacion + '" /></div>';
    strNuevaFila = strNuevaFila + '<div class="col-4 pe-2"><label class="form-label fw-bold">Observaciones:</label>';
    strNuevaFila = strNuevaFila + '<input class="form-control" placeholder="Observaciones" aria-required="true" name="observacionesFormacion_' + contadorFormacion + '" id="observacionesFormacion_' + contadorFormacion + '" /></div></div>';
    strNuevaFila = strNuevaFila + '<div class="row mt-3"><div class="col-4 pe-2"><label class="form-label fw-bold">Fecha Desde:</label>';
    strNuevaFila = strNuevaFila + '<input class="form-control" placeholder="Desde" aria-required="true" type="month" name="fechaDesdeFormacion_' + contadorFormacion + '" id="fechaDesdeFormacion_' + contadorFormacion + '"/></div>';
    strNuevaFila = strNuevaFila + '<div class="col-4 pe-2"><label class="form-label fw-bold">Fecha Hasta:</label>';
    strNuevaFila = strNuevaFila + '<input class="form-control" placeholder="Hasta" aria-required="true" type="month" name="fechaHastaFormacion_' + contadorFormacion + '" id="fechaHastaFormacion_' + contadorFormacion + '"/></div></div>';

    strNuevaFila = strNuevaFila + '<div class="row mt-3"><div class="col-4">';
    strNuevaFila = strNuevaFila + '<button class="btn btn-primary btnRemove" onclick="removeFormacion(' + contadorFormacion + ')">';
    strNuevaFila = strNuevaFila + '<i class="fas fa-minus me-3"></i>Quitar Formación</button></div></div></div><hr id="hrFormacion_' + contadorFormacion + '">';
    strNuevaFila = strNuevaFila + '<div class="row mt-3"><div class="col-4"><a class="btn btn-primary w-50" href="javascript:addFormacion();" id="btnAddFormacion">';
    strNuevaFila = strNuevaFila + '<i class="fa-solid fa-plus me-3"></i>Añadir Formación</a></div></div>';

    $("#bodyFormacion").append(strNuevaFila);
}

function removeFormacion(contInputs) {
    debugger;
    var idContainer = "#formacionContainer_" + contInputs;
    var hrContainer = "#hrFormacion_" + contInputs;
    var numInputs = $(".formacionContainerClass").length;
    $(idContainer).remove();
    $(hrContainer).remove();

    if (numInputs == 2) {
        $(".btnRemove").attr("disabled",true);
        $(".btnRemove").attr("onclick", "javascript: void(0);");
    }
}