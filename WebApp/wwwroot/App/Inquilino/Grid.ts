namespace EmpleadoGrid {

    declare var MensajeApp;

    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        })

    }

    export function OnClickEliminar(id){

        ComfirmAlert("Desea Eliminar El Registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Inquilino/Grid?handler=Eliminar&id=" + id;
                }
            })
    }

    $("#GridView").DataTable();

}