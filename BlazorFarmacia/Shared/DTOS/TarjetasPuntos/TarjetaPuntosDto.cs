using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFarmacia.Shared.DTOS.TarjetasPuntos
{
    public class TarjetaPuntosDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido.")]
        public int Folio { get; set; }
    }
}
