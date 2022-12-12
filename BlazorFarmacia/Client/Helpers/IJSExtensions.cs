﻿using Microsoft.JSInterop;

namespace BlazorFarmacia.Client.Helpers
{
    public static class IJSExtensions
    {
        public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);
        }

        //public static async ValueTask<object> MensajeEliminar(this IJSRuntime js, string titulo, string mensaje)
        //{
        //    return await js.InvokeAsync<object>()
        //}
    }
}