using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjetoStag026.Controllers
{
    public class RemedioController:Controller
    {

        public ActionResult ConsumindoApi()
        {
            HttpClient client;
            Uri usuarioUri;

            client = new HttpClient();
            client.BaseAddress = new Uri("https://componentesd.mybluemix.net/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplicativo / json"));
            //client.Encoding = UTF8Encoding.UTF8;
            HttpResponseMessage response = client.GetAsync("api/studentretrive").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                usuarioUri = response.Headers.Location;

                //Pegando os dados do Rest e armazenando na variável usuários
                List<Remedio>remedios = (List<Remedio>)response.Content.ReadAsAsync<IEnumerable<Remedio>>().Result;

                //preenchendo a lista com os dados retornados da variável
                ViewBag.Remedios = remedios;
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
            {
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
            }

            return View();
        }

    }
}