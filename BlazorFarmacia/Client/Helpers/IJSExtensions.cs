using Microsoft.JSInterop;

namespace BlazorFarmacia.Client.Helpers
{
    public static class IJSExtensions
    {
        public static Task MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);
        }
    }
}
