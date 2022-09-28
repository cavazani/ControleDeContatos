﻿using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio {
    public class ContatoRepositorio : IContatoRepositorio 
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) 
        { 
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id) 
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id); //Busca o primeiro ou o unico ID que existe la dentro
        }

        public List<ContatoModel> BuscarTodos() 
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato) 
        {
            //Gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
            
        }

        public ContatoModel Atualizar(ContatoModel contato) 
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
    }
}
