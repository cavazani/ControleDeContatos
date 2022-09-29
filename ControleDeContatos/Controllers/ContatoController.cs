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
            try {
               bool apagado = _contatoRepositorio.Apagar(Id);
                if (apagado) {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro) {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            try 
            {
                if (ModelState.IsValid) {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index"); //ação para redirecionar a index
                }
                return View(contato);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index"); //ação para redirecionar a index
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato) 
        {
            if (ModelState.IsValid) 
            {
                _contatoRepositorio.Atualizar(contato);
                return RedirectToAction("Index"); //ação para redirecionar a index

            }
            return View("Editar", contato);
        }
    }
}
