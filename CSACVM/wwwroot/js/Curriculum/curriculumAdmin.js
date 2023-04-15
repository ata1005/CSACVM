function inicializarTablaCurriculumsAdmin(cvs) {
    $("#tablaCurriculumsAdmin").DataTable({
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
                title: "Nombre usuario",
                data: "nombreCompleto",
                width: "28%",
                visible: true,
                searchable: false
            },
            {
                targets: 2,
                title: "Profesión",
                data: "profesion",
                width: "28%",
                visible: true,
                searchable: false
            },
            {
                targets: 3,
                title: "Última actualización",
                data: "ultimaActualizacion",
                type: 'datetime-moment',
                className: 'dt-body-center text-center',
                width: "20%",
                visible: true,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    return moment(new Date(data).toString()).format('D/M/YYYY HH:mm');
                }
            },
            {
                targets: 4,
                title: "Ver",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "8%",
                render: function (data, type, row) {
                    return '<a href="javascript:verCurriculum(\'' + row.idCurriculum + '\');"><i class="fa-solid fa-magnifying-glass fa-xl c-grey"></i></a>';
                }
            },
            {
                targets: 5,
                title: "PDF",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "8%",
                render: function (data, type, row) {
                    return '<a href="javascript:exportarPDF(\'' + row.idCurriculum + '\');"><i class="fa-solid fa-file-pdf fa-xl text-danger"></i></a>';
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

function filtrarCurriculums() {
    debugger;
    if (parseInt($("#filtroFechaNacimientoDesde").val()) > parseInt($("#filtroFechaNacimientoHasta").val()) && ($("#filtroFechaNacimientoDesde").val().toString() != "" && $("#filtroFechaNacimientoHasta").val().toString() != "")) {
        $("#alertFechas").removeClass("d-none");
        $("#alertFechas").addClass("d-flex");
    } else {
        var datosBusqueda = {
            filtroNombre: String($("#filtroNombre").val()),
            filtroProfesion: String($("#filtroProfesion").val()),
            filtroFechaNacimientoDesde: parseInt($("#filtroFechaNacimientoDesde").val()),
            filtroFechaNacimientoHasta: parseInt($("#filtroFechaNacimientoHasta").val()),
            filtroIdioma: parseInt($("#filtroIdioma").val()),
            filtroNivelIdioma: parseInt($("#filtroNivelIdioma").val()),
            filtroTipoFormacion: parseInt($("#filtroTipoFormacion").val()),
        }

        //Obtenemos los datos filtrados y recargamos la tabla de las solicitudes.
        $.ajax({
            type: "GET",
            url: "/Curriculum/ObtenerCurriculumsFiltro",
            data: datosBusqueda,
            async: true,
            success: function (response) {
                recargarTabla(response);
                $('#tablaCurriculumsAdmin').DataTable().columns.adjust();
            }
        });
    }
}

/**
 * Función para recargar la tabla con los filtros.
 * 
 * @var data datos de la tabla
 */
function recargarTabla(data) {
    if ($.fn.dataTable.isDataTable($("#tablaCurriculumsAdmin"))) {
        $('#tablaCurriculumsAdmin').DataTable().clear().draw();
        $('#tablaCurriculumsAdmin').DataTable().rows.add(data).draw();
        $('#tablaCurriculumsAdmin').DataTable().columns.adjust();
    } else {
        inicializarTablaCurriculumsAdmin(data);
    }
}

/**
 * Función para limpiar los filtros.
 */
function limpiarFiltros() {
    $("#filtroNombre").val('');
    $("#filtroProfesion").val('');
    $("#filtroFechaNacimientoDesde").val('');
    $("#filtroFechaNacimientoHasta").val('');
    $("#filtroIdioma").val(0);
    $("#filtroNivelIdioma").val(0);
    $("#filtroTipoFormacion").val(0);
    filtrarCurriculums();
    $("#filtroIdioma").val('Seleccione');
    $("#filtroNivelIdioma").val('Seleccione');
    $("#filtroTipoFormacion").val('Seleccione');
}

function exportarPDF(idCurriculum) {
    let url = '/Curriculum/ExportarPDF?idCurriculum=' + idCurriculum;
    window.open(url, '_blank');
}

function verCurriculum(idCurriculum) {
    $.ajax({
        type: "GET",
        url: "/Curriculum/ObtenerDatosModalVer",
        data: {
            'idCurriculum': parseInt(idCurriculum)
        },
        async: true,
        success: function (response) {
            var strNuevaFila = "";
            var divVerCV = "#divVerCV";
            modal = $('#modalVerCVAdmin')[0];
            $(modal).modal('toggle');
            modal.style.display = "block";
            strNuevaFila = ('<div class="row-12 d-flex ms-3">');
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Nombre completo:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.nombreCompleto + '</p></div>';
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Fecha Nacimiento:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.fechaNac + '</p></div>';
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Nacionalidad:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.nacionalidad + '</p></div></div>';
            strNuevaFila = strNuevaFila + '<div class="row-12 mt-2 d-flex ms-3">';
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Profesión:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.profesion + '</p></div>';
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Telefono:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.telefono + '</p></div>';
            strNuevaFila = strNuevaFila + '<div class="col-4 d-flex pe-2"><label class="form-label fw-bold" style="font-size:18px;text-decoration:underline"> Email:</label><p class="form-label ms-2" style="font-size:18px"> ' + response.email + '</p></div></div>';
            strNuevaFila = strNuevaFila + '<div class="row-12 mt-2 ms-3">';
            strNuevaFila = strNuevaFila + '<div class ="col-12 pe-2"><label class="form-label fw-bold"style="font-size:18px;text-decoration:underline"> Acerca de:</label>';
            strNuevaFila = strNuevaFila + '<p class="form-label ms-2" style="font-size:18px"> ' + response.acercaDe + '</p></div ></div >';

            $("#modalBodyVerCV").children(divVerCV).append(strNuevaFila);
        }
    });
}

function cerrarModal(nombreModal) {
    modalH = $("#" + nombreModal);
    modalH.modal('hide');
    $("#divVerCV").children().remove();
}



