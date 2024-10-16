let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/Admin/Persona/ObtenerTodos"
        },
        "columns": [
            { "data": "nombreApellido", "width": "20%" },
            { "data": "tipoDocumento", "width": "20%" },
            { "data": "fechaNacimiento", "width": "20%" },
            { "data": "valorGanar", "width": "20%" },
            { "data": "estadoCivil", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Persona/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="bi bi-pencil-square"></i>
                            <a/>
                            <a onclick=Delete("/Admin/Persona/Delete/${data}") class="btn btn-danger text-white" style="cursor:ponter">
                                <i class="bi bi-trash3-fill"></i>
                            <a/>
                        <div/>
                    
                    `;
                }, "with": "10%"
            },
        ]
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de eliminar?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                succes: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
