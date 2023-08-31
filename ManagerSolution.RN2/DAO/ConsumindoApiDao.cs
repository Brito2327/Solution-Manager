using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ManagerSolution.RN.DAO
{
    public class ConsumindoApiDao
    {
        public IList<Remedio> Consumir()
        {
            HttpClient client;
            Uri usuarioUri;

            client = new HttpClient();
            client.BaseAddress = new Uri("https://componentesd.mybluemix.net/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/studentretrive").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                usuarioUri = response.Headers.Location;

                //Pegando os dados do Rest e armazenando na variável do objeto Remedio
                List<Remedio> remedios = (List<Remedio>)response.Content.ReadAsAsync<IEnumerable<Remedio>>().Result;

                //preenchendo a lista com os dados retornados da variável
                return remedios;
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
            {
                List<Remedio> remedios = null;
                return remedios;
            }
        }
    }
}