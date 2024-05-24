using System.ComponentModel.DataAnnotations;

namespace DataAccessBlazor.Pages.FormsValidation
{
    public class WeatherForecastValidation
    {
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Date { get; set; }

        [Range(-100, 100, ErrorMessage = "La temperatura debe estar entre -100 y 100 grados Celsius.")]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required(ErrorMessage = "El resumen es obligatorio.")]
        [StringLength(100, ErrorMessage = "El resumen no debe exceder los 100 caracteres.")]
        public string Summary { get; set; }
    }
}
