using System;
using MetodosQuantitativos.Dominio.Entidades;
using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades.Biseccao;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Extencoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesBigInteger : IOperadorDeFracoes<BigInteger>
    {
        public Fracao<BigInteger> Simplificar(Fracao<BigInteger> fracao)
        {
            var fracaoResultado = new Fracao<BigInteger>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= BigInteger.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new Fracao<BigInteger>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<BigInteger> Somar(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<BigInteger> SomarDenominadorDiferente(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new Fracao<BigInteger>(numerador, denominador);
        }

        private static Fracao<BigInteger> SomarDenominadorIgual(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<BigInteger>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<BigInteger> Subtrair(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<BigInteger> SubtrairDenominadorIgual(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<BigInteger>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<BigInteger> SubtrairDenominadorDiferente(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<BigInteger>(numerador, denominador);
        }

        public Fracao<BigInteger> Multiplicar(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(new Fracao<BigInteger>(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public Fracao<BigInteger> Multiplicar(Fracao<BigInteger> fracao1, int multiplicador)
        {
            throw new NotImplementedException();
        }

        public Fracao<BigInteger> Dividir(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(new Fracao<BigInteger>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<BigInteger> Potenciar(Fracao<BigInteger> fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoBigInteger(1);
            }
            var fracaoResultado = new Fracao<BigInteger>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<BigInteger> Raiz(Fracao<BigInteger> fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracaoBigInteger();
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoBigInteger(1), raiz);
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoBigInteger(fracao.Numerador * -1), 0);
            var resultadoBiseccaoNumerador = Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracaoBigInteger();
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoBigInteger(1), raiz);
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoBigInteger(fracao.Denominador * -1), 0);
            var resultadoBiseccaoDenominador = Bisseccao(equacaoBiseccaoDenominador);

            return Dividir(resultadoBiseccaoNumerador, resultadoBiseccaoDenominador);
        }

        public Fracao<BigInteger> ValorDefault()
        {
            return new FracaoBigInteger(0);
        }

        public Fracao<BigInteger> CriarFracao(BigInteger numerador, BigInteger denominador)
        {
            return new Fracao<BigInteger>(numerador, denominador);
        }

        public Fracao<BigInteger> Media(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var somaDasDuasFracoes = Somar(fracao1, fracao2);
            return Dividir(somaDasDuasFracoes, new FracaoBigInteger(2, 1));
        }

        public Fracao<BigInteger> CalcularEquacao(EquacaoFracaoBigInteger equacao, Fracao<BigInteger> valorDeX)
        {
            Fracao<BigInteger> resultado = new FracaoBigInteger(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var resultP = Potenciar(valorDeX, elementoEquacao.Expoente);
                var resultM = Multiplicar(elementoEquacao.Coeficiente, resultP);
                resultado = Somar(resultado, resultM);
            }
            return resultado;
        }

        public Fracao<BigInteger> Bisseccao(EquacaoFracaoBigInteger equacao)
        {
            return Bisseccao(equacao, new FracaoBigInteger(1, 100));
        }

        public Fracao<BigInteger> Bisseccao(EquacaoFracaoBigInteger equacao, Fracao<BigInteger> erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public Fracao<BigInteger> Bisseccao(EquacaoFracaoBigInteger equacao, Fracao<BigInteger> erroMinimo, IntervaloBiseccao<Fracao<BigInteger>> valoresEntradaBiseccao)
        {
            var fracaoZero = new FracaoBigInteger(0);

            if (valoresEntradaBiseccao.ResultadoMenor.Igual(fracaoZero))
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Menor);
                return valoresEntradaBiseccao.Menor;
            }
            if (valoresEntradaBiseccao.ResultadoMaior.Igual(fracaoZero))
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Maior);
                return valoresEntradaBiseccao.Maior;
            }

            var numeroMenor = valoresEntradaBiseccao.Menor;
            var numeroMaior = valoresEntradaBiseccao.Maior;
            var mediaAnterior = Media(numeroMenor, numeroMaior);

            var media = Media(numeroMenor, numeroMaior);
            var resultadoNumeroMenor = CalcularEquacao(equacao, numeroMenor);
            var resultadoNumeroMaior = CalcularEquacao(equacao, numeroMaior);
            var resultadoMedia = CalcularEquacao(equacao, media);
            Fracao<BigInteger> erro;

            ImprimirLinhaBiseccao("X1", "XM", "X2", "F(X1)", "F(XM)", "F(X2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, "-");
            do
            {
                if (
                    ((resultadoNumeroMenor.MenorQue(fracaoZero) && resultadoNumeroMenor.MenorQue(resultadoMedia)) && resultadoMedia.MenorQue(fracaoZero)) ||
                    ((resultadoNumeroMenor.MaiorQue(fracaoZero) && resultadoNumeroMenor.MaiorQue(resultadoMedia)) && resultadoMedia.MaiorQue(fracaoZero)))
                    numeroMenor = media;
                if (
                    ((resultadoNumeroMaior.MaiorQue(fracaoZero) && resultadoNumeroMaior.MaiorQue(resultadoMedia)) && resultadoMedia.MaiorQue(fracaoZero)) ||
                    ((resultadoNumeroMaior.MenorQue(fracaoZero) && resultadoNumeroMaior.MenorQue(resultadoMedia)) && resultadoMedia.MenorQue(fracaoZero)))
                    numeroMaior = media;

                media = Media(numeroMenor, numeroMaior);
                resultadoNumeroMenor = CalcularEquacao(equacao, numeroMenor);
                resultadoNumeroMaior = CalcularEquacao(equacao, numeroMaior);
                resultadoMedia = CalcularEquacao(equacao, media);

                erro = Dividir(Subtrair(media, mediaAnterior), mediaAnterior).TransformarParaPositivo();
                mediaAnterior = media;
                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);

            } while (erro.MaiorQue(erroMinimo));

            Console.WriteLine("Resultado da Bisecção: " + media);
            Console.WriteLine();
            Console.WriteLine();
            return media;
        }

        public void ImprimirLinhaBiseccao(object numeroMenor, object media, object numeroMaior, object resultadoNumeroMenor, object resultadoNumeroMaior, object resultadoMedia, object erro)
        {
            Console.WriteLine("{0}    |{1}    |{2}    |{3}    |{4}     |{5}    |{6}    |", numeroMenor.ToString().PadLeft(15, ' '),
                media.ToString().PadLeft(15, ' '),
                numeroMaior.ToString().PadLeft(15, ' '),
                resultadoNumeroMenor.ToString().PadLeft(15, ' '),
                resultadoNumeroMaior.ToString().PadLeft(15, ' '),
                resultadoMedia.ToString().PadLeft(15, ' '),
                erro.ToString().PadLeft(15, ' '));
        }

        public IntervaloBiseccao<Fracao<BigInteger>> ObterValoresBiseccao(EquacaoFracaoBigInteger equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            var fracaoZero = new FracaoBigInteger(0);
            IntervaloBiseccao<Fracao<BigInteger>> intervaloEncontrado = null;
            var controlador = 1;
            var numeroInicial = 0;
            var numeroFinal = 0;

            const int numeroMaximoIteracoes = 100;
            for (var iteracao = 1; iteracao <= numeroMaximoIteracoes && intervaloEncontrado == null; iteracao++)
            {
                if (controlador > 0)
                {
                    numeroFinal += 10;
                }
                if (controlador < 0)
                {
                    numeroInicial -= 10;
                }
                controlador *= -1;

                Fracao<BigInteger> valorInicial = new FracaoBigInteger(numeroInicial);
                Fracao<BigInteger> valorFinal = new FracaoBigInteger(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = CalcularEquacao(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual.MenorOuIgualQue(valorFinal); numeroAtual = Somar(numeroAtual, new FracaoBigInteger(1)))
                {
                    var resultadoAtual = CalcularEquacao(equacao, numeroAtual);
                    if (intervaloEncontrado == null &&
                        ((resultadoAnterior.MenorQue(fracaoZero) && resultadoAtual.MaiorOuIgualQue(fracaoZero) || (resultadoAnterior.MaiorQue(fracaoZero) && resultadoAtual.MenorOuIgualQue(fracaoZero)))))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<Fracao<BigInteger>>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
                    }
                    numeroAnterior = numeroAtual;
                    resultadoAnterior = resultadoAtual;
                    ImprimirLinhaBuscaValorBiseccao(numeroAtual, resultadoAtual);
                }
            }


            Console.WriteLine("Primeiro intervalo encontrado: {0}", intervaloEncontrado);
            Console.WriteLine();
            Console.WriteLine();
            return intervaloEncontrado;
        }

        public void ImprimirLinhaBuscaValorBiseccao(object numero, object resultado)
        {
            Console.WriteLine("{0}    |{1}    |", numero.ToString().PadLeft(15, ' '), resultado.ToString().PadLeft(15, ' '));
        }
    }
}