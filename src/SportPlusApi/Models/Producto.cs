using System.ComponentModel.DataAnnotations;

namespace SportPlusApi.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}