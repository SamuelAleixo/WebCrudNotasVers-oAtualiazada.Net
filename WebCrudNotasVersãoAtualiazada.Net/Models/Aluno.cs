using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace WebCrudNotasVersãoAtualiazada.Net.Models
{
    public class Aluno
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public int nota1 { get; set; }
        public int nota2 { get; set; }

       

        public double notaFinal
        {
            get
            {
                return (nota1 + nota2) / 2.0;
            }
        }
        public string mensagem
        {
            get
            {
                return notaFinal >= 6 ? "Aprovado" : "Não Aprovado";
            }
        }
    }
}


