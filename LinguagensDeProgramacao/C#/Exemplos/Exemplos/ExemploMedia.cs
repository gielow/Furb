using System;
using NUnit.Framework;

namespace Exemplos
{
    public class ExemploMedia
    {
        [Test]
        public void calculo_media()
        {
            const int notaProva1 = 6;
            const int notaProva2 = 6;
            const int notaProva3 = 5;
            var media = (notaProva1 + notaProva2 + notaProva3) / 3d;
            Console.WriteLine(media);
        }

        [Test]
        public void calculo_media_brasileira()
        {
            const int quantitadeAlunosNoBrasil = 999999999;
            const int notaProva1 = 6;
            const int notaProva2 = 6;
            const int notaProva3 = 5;

            var somaDasMediasBrasileiras = 0d;
            for (var i = 0; i < quantitadeAlunosNoBrasil; i++)
            {
                somaDasMediasBrasileiras += (notaProva1 + notaProva2 + notaProva3) / 3d;
            }
            var mediaBrasileira = somaDasMediasBrasileiras/quantitadeAlunosNoBrasil;
            Console.WriteLine(mediaBrasileira);
        }
    }
}