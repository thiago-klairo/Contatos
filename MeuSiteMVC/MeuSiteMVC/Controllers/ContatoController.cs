using MeuSiteMVC.Models;
using MeuSiteMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSiteMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Apagar(int id) 
        {
            try { 
           bool apagado = _contatoRepositorio.Apagar(id);
           if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else { 
                    TempData["MensageError"] = $" Não foi possível deletar o contato.";
                }
                return RedirectToAction("Index");
            
            } 
            catch(System.Exception error)
            {
                TempData["MensageError"] = $" Não foi possível deletar o contato.";
                return RedirectToAction("index");
            }
        }
        

        public IActionResult Criar()
        {         
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
        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
           {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso.";
                    //Redireciona para o index
                    return RedirectToAction("Index");
                }

                return View(contato);
            }   
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o contato. detalhe do erro: :{erro.Message} ";
                //Redireciona para o index
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try { 
            if(ModelState.IsValid) { 
            _contatoRepositorio.Atualizar(contato);
                    //Redireciona para o index
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
            return RedirectToAction("Index");
            }
            return View("Editar", contato);
            }
            catch(System.Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o contato. detalhe do erro: :{error.Message} ";
                //Redireciona para o index
                return RedirectToAction("Index");
            }
            }
    }
}
