﻿using ControleDeContatos.Models;
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
        public IActionResult Index() {
            _contatoRepositorio.BuscarTodos();
            return View();
        }

        public IActionResult Criar() {
            return View();
        }

        public IActionResult Editar() {
            return View();
        }

        public IActionResult ApagarConfirmacao() {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index"); //ação para redirecionar a index
        }
    }
}
