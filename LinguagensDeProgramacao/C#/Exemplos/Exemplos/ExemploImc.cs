using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Exemplos
{
    public class ExemploImc
    {
        [Test]
        public void calculo_imc_pessoa_dentro_do_peso()
        {
            const int peso = 80;
            const double altura = 1.80;
            var imc = peso / Math.Pow(altura, 2);
            Console.WriteLine(imc);
        }

        [Test]
        public void calculo_imc_pessoa_dentro_do_peso_media_mundial()
        {
            const int quantitadePessoalNoMundo = 70000000;
            const int peso = 80;
            const double altura = 1.80;

            var imcTotal = 0d;
            for (var i = 0; i < quantitadePessoalNoMundo; i++)
            {
                imcTotal += peso / Math.Pow(altura, 2);
            }
            var mediaImcMundial = imcTotal / quantitadePessoalNoMundo;
            Console.WriteLine(mediaImcMundial);
        }
    }
}
