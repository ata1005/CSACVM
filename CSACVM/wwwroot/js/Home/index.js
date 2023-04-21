function filtrarEntradas() {
    if (parseInt($("#filtroEntradaFechaDesde").val()) > parseInt($("#filtroEntradaFechaHasta").val()) && ($("#filtroEntradaFechaDesde").val().toString() != "" && $("#filtroEntradaFechaHasta").val().toString() != "")) {
        $("#alertFechasEntrada").removeClass("d-none");
        $("#alertFechasEntrada").addClass("d-flex");
    } else {
        var nombre = String($("#filtroNombreEntrada").val());
        var fechaDesde = String($("#filtroEntradaFechaDesde").val());
        var fechaHasta = String($("#filtroEntradaFechaHasta").val());
        var descripcion = String($("#filtroDescripcionEntrada").val());
        window.location.href = "/Home/ObtenerEntradasFiltro/?filtroNombre=" + nombre + "&filtroFechaDesde=" + fechaDesde + "&filtroFechaHasta=" + fechaHasta + "&filtroDescripcion=" + descripcion ;
    }
}