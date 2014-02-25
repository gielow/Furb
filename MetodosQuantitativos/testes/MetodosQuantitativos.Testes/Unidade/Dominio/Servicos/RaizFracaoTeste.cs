using System;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class RaizFracaoTeste
    {
        [Test]
        public void TentandoDividirUmaFracao()
        {
            double potencia1 = 1.0 / 3.0;
            double potencia2 = 2.0 / 3.0;
            double raiz5 = Math.Pow(5, potencia1);
            double raiz3 = Math.Pow(3, potencia1);
            double result = raiz5 / raiz3;

            double _raiz5 = Math.Pow(3, potencia2);
            double _raiz3 = Math.Pow(5, potencia2);
            double resultM = (5 * _raiz5) / (3*_raiz3);
            double result2 = (resultM) / 75;

            Console.WriteLine("Result1 : " + resultM);
            Console.WriteLine("Result2 : " + result2);
        }
    }
}