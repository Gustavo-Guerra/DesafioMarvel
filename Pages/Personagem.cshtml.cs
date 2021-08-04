using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Marvel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Marvel.Pages
{
    public class PersonagemModel : PageModel
    {
        private readonly ILogger<PersonagemModel> _logger;

        public CharacterDataWrapper dataWrapper;

        public bool achouPersonagem;
        public PersonagemModel(ILogger<PersonagemModel> logger)
        {
            _logger = logger;
        }

        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }


        public CharacterDataWrapper consultaPersonagem(IConfiguration config, string nomePersonagem)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = GerarHash(ts, publicKey,
                    config.GetSection("MarvelComicsAPI:PrivateKey").Value);
                string Url = config.GetSection("MarvelComicsAPI:BaseURL").Value +
                    $"characters?ts={ts}&apikey={publicKey}&hash={hash}";
                if (!string.IsNullOrEmpty(nomePersonagem))
                {
                    Url += "&" + $"name={Uri.EscapeUriString(nomePersonagem)}";
                }
                _logger.LogDebug(Url);
                HttpResponseMessage response = client.GetAsync(Url).Result;


                response.EnsureSuccessStatusCode();
                string conteudo =
                response.Content.ReadAsStringAsync().Result;


                var result = JsonSerializer.Deserialize<CharacterDataWrapper>(conteudo);
                if (result == null || result.data.count == 0)
                {
                    achouPersonagem = false;
                    return null;
                }
                else
                {
                    achouPersonagem = true;
                    return result;
                }
            }
        }
        public void OnGet([FromServices] IConfiguration config, [FromQuery] string nomePersonagem)
        {
           // dataWrapper = string.IsNullOrEmpty(nomePersonagem) ? new CharacterDataWrapper() : consultaPersonagem(config, nomePersonagem);
            if (string.IsNullOrEmpty(nomePersonagem))
            {
                dataWrapper = new CharacterDataWrapper();
            }
            else {
                dataWrapper=consultaPersonagem(config, nomePersonagem);
            }
        }
    }
}
