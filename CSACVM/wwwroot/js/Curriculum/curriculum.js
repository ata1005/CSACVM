
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