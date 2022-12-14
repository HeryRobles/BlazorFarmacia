function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.value) {
                resolve(true);
            }
            else {
                resolve(false);
            }
        });
    });
}

//function Confirmar(titulo, mensaje, tipo) {
//    return new Promise(resolve => {
//        Swal.fire({
//            titulo,
//            mensaje,
//            tipo,
//            showCancelButton: true,
//            confirmButtonColor: '#3085d6',
//            cancelButtonColor: '#d33',
//            confirmButtonText: 'Sí, eliminar!'
//        }).then((result) => {
//            resolve(result.isConfirmed);

//        })   
//    }
//}

