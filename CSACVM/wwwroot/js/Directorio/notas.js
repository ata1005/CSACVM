function inicializarTablaNotas(notas) {

    $("#tablaNotas").DataTable({
        data: notas,
        orderCellsTop: true,
        paging: false,
        destroy: true,
        order: [1, "asc"],
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
                title: "Descripción nota",
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
                targets: 3,
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
                targets: 3,
                title: "Eliminar",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:editarSolicitud(\'' + row.idSolicitud + '\');"><i class="fa-solid fa-pen fa-xl c-grey"></i></a>';
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