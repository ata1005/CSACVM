function inicializarTablaUsuariosAdmin(cvs) {
    $("#tablaUsuariosAdmin").DataTable({
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
                title: "Nombre usuario",
                data: "nombreUser",
                width: "25%",
                visible: true,
                searchable: false
            },
            {
                targets: 2,
                title: "Nombre",
                data: "nombre",
                width: "20%",
                visible: true,
                searchable: false
            },
            {
                targets: 3,
                title: "Apellido",
                data: "apellido",
                width: "20%",
                visible: true,
                searchable: false
            },
            {
                targets: 4,
                title: "Activo",
                data: "activo",
                className: 'dt-body-center text-center',
                width: "10%",
                visible: true,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    if (row.activo) {
                        return '<i class="fa-solid fa-xl fa-check text-success"></i>';
                    } else {
                        return '<i class="fa-solid fa-xl fa-xmark text-danger"></i>';
                    }
                }
            },
            {
                targets: 5,
                title: "Admin",
                data: "esAdmin",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    if (row.esAdmin) {
                        return '<i class="fa-solid fa-xl fa-check text-success"></i>';
                    } else {
                        return '<i class="fa-solid fa-xl fa-xmark text-danger"></i>';
                    }

                }
            },
            {
                targets: 6,
                title: "Ver",
                visible: true,
                orderable: false,
                searchable: false,
                className: 'dt-body-center text-center',
                width: "10%",
                render: function (data, type, row) {
                    return '<a href="javascript:cargarUsuario(\'' + row.idUsuario + '\');"><i class="fa-solid fa-magnifying-glass fa-xl c-grey"></i></a>';
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


function cargarUsuario(idUsuario) {
    $.ajax({
        type: "GET",
        url: "/Mantenimiento/ObtenerUsuario",
        data: {
            'idUsuario': idUsuario
        },
        async: true,
        success: function (response) {
            var activo = false;
            var admin = false;
            if (response.esAdmin) admin = true;
            if (response.activo) activo = true;
            $("#nombreAdmin").val(response.nombre);
            $("#nombreUsuarioAdmin").val(response.nombreUser);
            $("#apellidoAdmin").val(response.apellido);
            $("#idUsuarioAdmin").val(response.idUser);
            $("#activoAdmin").prop("checked", activo);
            $("#esAdminAdmin").prop("checked", admin);
        }
    });
}

function guardarCambios() {
    var activo = false;
    var admin = false;
    if ($("#esAdminAdmin").prop("checked")) admin = true;
    if ($("#activoAdmin").prop("checked")) activo = true;

    $.ajax({
        type: "POST",
        url: "/Mantenimiento/ActualizarUsuario",
        data: {
            'idUsuario': $("#idUsuarioAdmin").val(),
            'nombreUser': $("#nombreUsuarioAdmin").val(),
            'nombre': $("#nombreAdmin").val(),
            'apellido': $("#apellidoAdmin").val(),
            'activo': activo,
            'esAdmin': admin
        },
        async: true,
        success: function (response) {
            window.location.reload();
        }
    });
}

function filtrarUsuarios() {

    var datosBusqueda = {
        filtroNombre: String($("#filtroNombre").val()),
        filtroLogin: String($("#filtroLogin").val()),
        filtroApellido: String($("#filtroApellido").val()),
        filtroAdmin: document.getElementById("filtroAdmin").checked,
        filtroActivo: document.getElementById("filtroActivo").checked,
        filtroTodos: document.getElementById("filtroTodos").checked,
    }

    //Obtenemos los datos filtrados y recargamos la tabla de las solicitudes.
    $.ajax({
        type: "GET",
        url: "/Mantenimiento/ObtenerUsuariosFiltro",
        data: datosBusqueda,
        async: true,
        success: function (response) {
            recargarTabla(response);
            $('#tablaUsuariosAdmin').DataTable().columns.adjust();
        }
    });

}

/**
 * Función para recargar la tabla con los filtros.
 * 
 * @var data datos de la tabla
 */
function recargarTabla(data) {
    if ($.fn.dataTable.isDataTable($("#tablaUsuariosAdmin"))) {
        $('#tablaUsuariosAdmin').DataTable().clear().draw();
        $('#tablaUsuariosAdmin').DataTable().rows.add(data).draw();
        $('#tablaUsuariosAdmin').DataTable().columns.adjust();
    } else {
        inicializarTablaUsuariosAdmin(data);
    }
}

$("#filtroTodos").change(function (e) {
    //var sel = document.getElementById("IdIdValorUnidadCajaBalde");
    e.stopImmediatePropagation();
    if (document.getElementById("filtroTodos").checked) {
        $("#filtroActivo").attr('disabled', true);
        $("#filtroAdmin").attr('disabled', true);
        $("#filtroActivo").prop('checked', false);
        $("#filtroAdmin").prop('checked', false);
    } else {
        $("#filtroActivo").removeAttr("disabled");
        $("#filtroAdmin").removeAttr("disabled");
    }
});