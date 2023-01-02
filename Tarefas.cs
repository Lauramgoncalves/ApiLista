using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04
{
    class Tarefas  // Classe
    {
        public int userId;
        public int id;
        public string title;   // Tem que ter o mesmo nome que vem dá resposta.
        public bool completed;
       
        
        
        public void Exibir()  // Metodo
        {
            Console.WriteLine("Objeto Tarefa" +
                "");
            Console.WriteLine($"User id: {userId}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Titulo: {title}");
            Console.WriteLine($"Status: {completed}");
            Console.WriteLine("");
            Console.WriteLine("===========================================");
            Console.WriteLine("");


        }
    }
}