using EYCD03092024Materias.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EYCD03092024Materias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        //Declaracion de una lista estatica de objetos
        //"Materia" para almacenar materias.
        static List<Materia> materias = new List<Materia>();

        //Definicion de un metodo HTTP GET
        //Que devuelve una coleccion de clientes
        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return materias;
        }

        //Definicion de un metodo HTTP GET 
        //Que recibe un ID como parametro y devuelve una materia especifica
        [HttpGet("{id}")]
        public Materia Get(int id)
        {
            var materia = materias.FirstOrDefault(c => c.Id == id);
            return materia;
        }

        //Definicion de un metodo HTTP POST 
        //para agregar una nueva materia a la lista
        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            materias.Add(materia);
            return Ok();
        }

        //Definicion de un metodo HTTP PUT
        //para actualizar una materia existente en la lista por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Materia materia)
        {
            var existingMateria = materias.FirstOrDefault(c => c.Id == id);
            if(existingMateria != null)
            {
                existingMateria.Nombre = materia.Nombre;
                existingMateria.Descripcion = materia.Descripcion;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Definicion de un metodo HTTP DELETE 
        //para eliminar un cliente por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMateria = materias.FirstOrDefault(c => c.Id == id);
            if(existingMateria != null)
            {
                materias.Remove(existingMateria);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
