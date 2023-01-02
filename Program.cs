using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net; // Para fazer requisição.
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Converte textos em dados para csharp

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        { /*   *Int e protocolo HTTP - Leva e tras dados.
           O que é? é uma requisição para um servidor(é um computador, toda a lógica por trás),
           o servidor se comunica, processa e responde com o arquivo web e exibe ao usuario.*/

            /* JSON é um formato de dados para compartilhamento de informaçoes na web entre linguagens diferentes,
             * Exemplo {"nome": coração de aço
                         "preço": 12.50}
                          } */

            //ReqLista();
            ReqUnica();
            Console.ReadLine();



        }

        // Para fazer requisição

        static void ReqLista()
        {
            //Cadastro de requisição
            var requisição = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            /*WebRequest é um objeto que é gerado para fazer requisição pra uma url ue será passada.
            Get - Requisição direta  */
            requisição.Method = "GET";

            // Executa a requisição
            var resposta = requisição.GetResponse();
            using (resposta) // Using trabalha bem com requisição web
            { // Pega a resposta ue o site retorna e decondificando ela.
                var stream = resposta.GetResponseStream();
                // O StreamReader é um cara responsavel por pegar os dados da stream(resposta) e vai tentar le os dados.
                StreamReader leitor = new StreamReader(stream);
                //Pega os dados atraves do leitor
                object dados = leitor.ReadToEnd();

                //Console.WriteLine(dados.ToString()); // ToString converte o objeto para string.
                List<Tarefas> tarefas = JsonConvert.DeserializeObject<List<Tarefas>>(dados.ToString()); // Converte todos os dados em json para uma lista de tarefas.
                                                                                                        // Console.WriteLine(tarefas);
                foreach (Tarefas tarefa in tarefas)
                {
                    tarefa.Exibir();
                }

                stream.Close(); // toda a stream criada tem que ser fechada.
                resposta.Close(); // pra dizer ao servidor que já fizemos a requisição, e que não precisamos mais dele.
            }

        }



        // Requisição de dados unicos

        static void ReqUnica()
        {
            //Cadastro de requisição
            var requisição = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/5");
            /*WebRequest é um objeto que é gerado para fazer requisição pra uma url ue será passada.
            Get - Requisição direta  */
            requisição.Method = "GET";

            // Executa a requisição
            var resposta = requisição.GetResponse();
            using (resposta) // Using trabalha bem com requisição web
            { // Pega a resposta que o site retorna e decondificando ela.
                var stream = resposta.GetResponseStream();
                // O StreamReader é um cara responsavel por pegar os dados da stream(resposta) e vai tentar le os dados.
                StreamReader leitor = new StreamReader(stream);
                //Pega os dados atraves do leitor
                object dados = leitor.ReadToEnd();

                //Console.WriteLine(dados.ToString()); // ToString converte o objeto para string.
                Tarefas tarefa = JsonConvert.DeserializeObject<Tarefas>(dados.ToString()); // Converte todos os dados em json para uma string.
                                                                                           // Console.WriteLine(tarefas);
                tarefa.Exibir();

                stream.Close(); // toda a stream criada tem que ser fechada.
                resposta.Close(); // pra dizer ao servidor que já fizemos a requisição e que não precisamos mais dele.
            }
        }
    }
}
