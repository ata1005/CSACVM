
function inicializarTablaNotas(notas) {
    $("#tablaNotas").DataTable({
        data: notas,
        orderCellsTop: true,
        paging: false,
        destroy: true,
        order: [2, "desc"],
        scrollX: true,
        columnDefs: [
            {
                targets: 0,
                title: "Id Nota",
                data: "idNotaUsuario",
                visible: false,
                searchable: false
            },
            {
                targets: 1,
                title: "Título de la nota",
                data: "titulo",
                width: "50%",
                visible: true,
                searchable: false
            },
            {
                targets: 2,
                title: "Fecha creación",
                data: "fechaCreacion",
                width: "20%",
                visible: true,
                orderable: false,
                searchable: false
            },
            {
                targets: 3,
                title: "Ver",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:verNota(\'' + row.idNotaUsuario + '\');"><i class="fa-solid fa-magnifying-glass fa-xl c-grey"></i></a>';
                }
            },
            {
                targets: 4,
                title: "Editar",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:editarNota(\'' + row.idNotaUsuario + '\');"><i class="fa-solid fa-pen fa-xl c-grey"></i></a>';
                }
            },
            {
                targets: 5,
                title: "Eliminar",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:eliminarNota(\'' + row.idNotaUsuario + '\');"><i class="fa-solid fa-trash fa-xl c-grey"></i></a>';
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

function editarNota(idNotaUsuario) {
    $.ajax({
        type: "POST",
        url: "/Directorio/EditarNota",
        data: {
            'idNota': parseInt(idNotaUsuario)
        },
        async: true,
        success: function (response) {

        }
    });

}

function eliminarNota(idNotaUsuario) {
    $.ajax({
        type: "POST",
        url: "/Directorio/EliminarNota",
        data: {
            'idNota': parseInt(idNotaUsuario)
        },
        async: true,
        success: function (response) {

        }
    });
}