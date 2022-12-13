using Microsoft.JSInterop;

namespace BlazorFarmacia.Client.Helpers
{
    public static class IJSExtensions
    {
        public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);
        }

        public static async ValueTask<bool> Confirmar(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje, tipoMensajeSweetAlert.ToString());
        }

        //public static async ValueTask<object> MensajeEliminar(this IJSRuntime js, string titulo, string mensaje)
        //{
        //    return await js.InvokeAsync<object>()
        //}
    }

    public enum TipoMensajeSweetAlert
    {
        question, warning, error, success, info
    }
}
