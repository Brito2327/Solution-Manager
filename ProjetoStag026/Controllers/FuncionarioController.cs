using ProjetoStag026.DAO;
using ProjetoStag026.Filtros;
using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{[FiltroF]
    public class FuncionarioController:Controller
    {
        public ActionResult Index()
        {
            FuncionarioDao dao = new FuncionarioDao();
            IList<Funcionario> funcionarios = dao.Select();

            ViewBag.Funcionarios = funcionarios;
            return View();
        }


        public ActionResult Cadastrar(Funcionario funcionario,Usuario usuario)
        {
            UsuarioDao us = new UsuarioDao();
            FuncionarioDao dao = new FuncionarioDao();
            CategoriasDAO cat = new CategoriasDAO();
            Categoria categoria = new Categoria();
            categoria.Atendente = true;
            cat.Cadastrar(categoria);
            usuario.CategoriaId = categoria.Id;
            us.Cadastrar(usuario);
            funcionario.UsuarioId = usuario.ID;

            dao.Cadastrar(funcionario);

            return RedirectToAction("Index");
        }

        public ActionResult update(Funcionario funcionario)
        {
            FuncionarioDao dao = new FuncionarioDao();
            string valida = dao.Alterar(funcionario) ? "Sim" : "nao";
            return Json(valida);
        }


        public ActionResult Excluir(int id)
        {
            FuncionarioDao dao = new FuncionarioDao();
            
            string validacao = (dao.excluir(id) ? "Sim" : "Não");
            return Json(validacao);

        }
        public ActionResult Dashbord()
        {
            AgendamentoDao dao = new AgendamentoDao();
            IList<Agendamento> lista = dao.Select().ToList();
            lista.Count();
            ViewBag.Agendamentos = lista;
            return View();
        }
    }
}