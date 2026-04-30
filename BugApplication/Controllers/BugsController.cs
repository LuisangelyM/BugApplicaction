using Microsoft.AspNetCore.Mvc;
using BugApplication.Models; 
using BugApplication.Services; 

namespace BugApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // La ruta será: api/bugs
    public class BugsController : ControllerBase
    {
        private readonly BugService _bugService;

        // Visual Studio te marcará error en BugService si no lo has 
        // registrado en el Program.cs o si falta el 'using'
        public BugsController(BugService bugService)
        {
            _bugService = bugService;
        }

        // Obtener todos los bugs (GET)
        [HttpGet]
        public IActionResult Get()
        {
            var bugs = _bugService.ObtenerTodos();
            return Ok(bugs);
        }

        // Guardar un nuevo bug (POST)
        [HttpPost]
        public IActionResult Post([FromBody] Bug nuevoBug)
        {
            if (nuevoBug == null) return BadRequest();

            _bugService.Crear(nuevoBug);
            return Ok(new { mensaje = "Bug guardado en SQL!" });
        }
    }
}