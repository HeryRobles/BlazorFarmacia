using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFarmacia.Shared.DTOS.LotesProductos
{
    public class LoteProductoDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido.")]
        public int Lote { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido.")]
        public DateTime FechaCaducidad { get; set; }



    }
}
