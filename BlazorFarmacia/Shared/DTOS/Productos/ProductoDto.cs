using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFarmacia.Shared.DTOS.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Descripcion { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido.")]
        public decimal ValorUnitario { get; set; }

        public string UbicacionProducto { get; set; }




    }
}
