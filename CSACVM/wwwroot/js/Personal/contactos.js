function inicializarTablaBuscarContactos(cvs) {
    $("#tablaBuscarContactos").DataTable({
        data: cvs,
        orderCellsTop: true,
        paging: false,
        destroy: true,
        order: [1, "asc"],
        scrollX: true,
        columnDefs: [
            {
                targets: 0,
                title: "Id Usuario",
                data: "idUsuario",
                visible: false,
                searchable: false
            },
            {
                targets: 1,
                title: "Foto",
                data: "foto",
                class: "text-center",
                width: "10%",
                visible: true,
                searchable: false,
                render: function (data, type, row) {
                    if (row.foto != "") {
                        debugger;
                        var str = "/" + row.foto.split("/")[2] + "/" + row.foto.split("/")[3];
                        return '<img src="' + str + '" style="width: 60px;height:70px" class="br-100">';
                    } else {
                        return '<img src="/images/defaultUser.jpg" style="width: 60px;height:70px" class="br-100">';
                    }
                    
                }
            },
            {
                targets: 2,
                title: "Nombre",
                data: "nombre",
                width: "15%",
                visible: true,
                searchable: false
            },
            {
                targets: 3,
                title: "Email",
                data: "email",
                width: "15%",
                visible: true,
                searchable: false
            },
            {
                targets: 4,
                title: "Departamento",
                data: "departamento",
                className: 'dt-body-center text-center',
                width: "20%",
                visible: true,
                orderable: false,
                searchable: false
            },
            {
                targets: 5,
                title: "Rol",
                data: "rol",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%"
            },
            {
                targets: 6,
                title: "Añadir",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:anadirContacto(\'' + row.idUsuario + '\');"><i class="fa-solid fa-circle-plus fa-xl text-success"></i></a>';
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

function inicializarTablaContactos(cvs) {
    $("#tablaContactos").DataTable({
        data: cvs,
        orderCellsTop: true,
        paging: false,
        destroy: true,
        order: [1, "asc"],
        scrollX: true,
        columnDefs: [
            {
                targets: 0,
                title: "Id Usuario",
                data: "idUsuario",
                visible: false,
                searchable: false
            },
            {
                targets: 1,
                title: "Foto",
                data: "foto",
                class: "text-center",
                width: "10%",
                visible: true,
                searchable: false,
                render: function (data, type, row) {
                    if (row.foto != "") {
                        debugger;
                        var str = "/" + row.foto.split("/")[2] + "/" + row.foto.split("/")[3];
                        return '<img src="'+str+'" style="width: 60px;height:70px" class="br-100">';
                    } else {
                        return '<img src="/images/defaultUser.jpg" style="width: 60px;height:70px" class="br-100">';
                    }

                }
            },
            {
                targets: 2,
                title: "Nombre",
                data: "nombre",
                width: "15%",
                visible: true,
                searchable: false
            },
            {
                targets: 3,
                title: "Email",
                data: "email",
                width: "15%",
                visible: true,
                searchable: false
            },
            {
                targets: 4,
                title: "Departamento",
                data: "departamento",
                className: 'dt-body-center text-center',
                width: "20%",
                visible: true,
                orderable: false,
                searchable: false
            },
            {
                targets: 5,
                title: "Rol",
                data: "rol",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%"
            },
            {
                targets: 6,
                title: "Quitar",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:quitarContacto(\'' + row.idUsuario + '\');"><i class="fa-solid fa-circle-minus fa-xl text-danger"></i></a>';
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

function anadirContacto(idUsuario) {
    debugger;
    $.ajax({
        type: "POST",
        url: "/Personal/AnadirContacto",
        data: {
            'idUsuario': idUsuario
        },
        async: true,
        success: function (response) {
            window.location = "/Personal/Contactos";
        }
    });
}

function quitarContacto(idUsuario) {
    $.ajax({
        type: "POST",
        url: "/Personal/EliminarContacto",
        data: {
            'idUsuario': idUsuario
        },
        async: true,
        success: function (response) {
            window.location = "/Personal/Contactos";
        }
    });
}
