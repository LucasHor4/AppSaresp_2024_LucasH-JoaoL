using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace AppSaresp_2024.Controllers
{
    public class ProfessorAplicadorController : Controller
    {
        private IProfessorAplicadorRepository _professorAplicadorRepository;
        public ProfessorAplicadorController(IProfessorAplicadorRepository professorAplicadorRepository)
        {
            _professorAplicadorRepository = professorAplicadorRepository;
        }
        public IActionResult Index()
        {
            return View(_professorAplicadorRepository.ObterTodosProfessores());
        }
        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorAplicador professor)
        {
            if (ModelState.IsValid)
            {
                _professorAplicadorRepository.Cadastrar(professor);
            }
            return View();
        }
    }
}
