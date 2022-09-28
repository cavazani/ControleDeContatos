using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers {
    public class ContatoController : Controller {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }

        //Metodo action criado por padrão para essa controller
        public IActionResult Index() 
         {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar() {
            return View();
        }

        public IActionResult Editar(int id) 
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id) 
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        //Metodo para pagar registro
        public IActionResult Apagar(int Id) 
        {
            _contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            if (ModelState.IsValid) 
            {
                _contatoRepositorio.Adicionar(contato);
                return RedirectToAction("Index"); //ação para redirecionar a index
            }
            
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato) 
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index"); //ação para redirecionar a index
        }
    }
}
