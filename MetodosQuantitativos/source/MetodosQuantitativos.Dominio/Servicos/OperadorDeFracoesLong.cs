using System;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Biseccao;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Extencoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesLong : IOperadorDeFracoes<long>
    {
        public Fracao<long> Simplificar(Fracao<long> fracao)
        {
            var fracaoResultado = new Fracao<long>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new Fracao<long>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<long> Somar(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<long> SomarDenominadorDiferente(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new Fracao<long>(numerador, denominador);
        }

        private static Fracao<long> SomarDenominadorIgual(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<long>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<long> Subtrair(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<long> SubtrairDenominadorIgual(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<long>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<long> SubtrairDenominadorDiferente(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<long>(numerador, denominador);
        }

        public Fracao<long> Multiplicar(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(new Fracao<long>(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public Fracao<long> Multiplicar(Fracao<long> fracao1, int multiplicador)
        {
            throw new NotImplementedException();
        }

        public Fracao<long> Dividir(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(new Fracao<long>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<long> Potenciar(Fracao<long> fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoLong(1);
            }
            var fracaoResultado = new Fracao<long>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<long> Raiz(Fracao<long> fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracaoLong();
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoLong(1), raiz);
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoLong(fracao.Numerador * -1), 0);
            var resultadoBiseccaoNumerador = Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracaoLong();
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoLong(1), raiz);
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoLong(fracao.Denominador * -1), 0);
            var resultadoBiseccaoDenominador = Bisseccao(equacaoBiseccaoDenominador);

            return Dividir(resultadoBiseccaoNumerador, resultadoBiseccaoDenominador);
        }

        public Fracao<long> ValorDefault()
        {
            return new FracaoLong(0);
        }

        public Fracao<long> CriarFracao(long numerador, long denominador)
        {
            return new Fracao<long>(numerador, denominador);
        }

        public Fracao<long> Media(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var somaDasDuasFracoes = Somar(fracao1, fracao2);
            return Dividir(somaDasDuasFracoes, new FracaoLong(2, 1));
        }

        public Fracao<long> CalcularEquacao(EquacaoFracaoLong equacao, Fracao<long> valorDeX)
        {
            Fracao<long> resultado = new FracaoLong(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var resultP = Potenciar(valorDeX, elementoEquacao.Expoente);
                var resultM = Multiplicar(elementoEquacao.Coeficiente, resultP);
                resultado = Somar(resultado, resultM);
            }
            return resultado;
        }

        public Fracao<long> Bisseccao(EquacaoFracaoLong equacao)
        {
            return Bisseccao(equacao, new FracaoLong(1, 100));
        }

        public Fracao<long> Bisseccao(EquacaoFracaoLong equacao, Fracao<long> erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public Fracao<long> Bisseccao(EquacaoFracaoLong equacao, Fracao<long> erroMinimo, IntervaloBiseccao<Fracao<long>> valoresEntradaBiseccao)
        {
            var fracaoZero = new FracaoLong(0);

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
            Fracao<long> erro;

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

        public IntervaloBiseccao<Fracao<long>> ObterValoresBiseccao(EquacaoFracaoLong equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            var fracaoZero = new FracaoLong(0);
            IntervaloBiseccao<Fracao<long>> intervaloEncontrado = null;
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

                Fracao<long> valorInicial = new FracaoLong(numeroInicial);
                Fracao<long> valorFinal = new FracaoLong(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = CalcularEquacao(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual.MenorOuIgualQue(valorFinal); numeroAtual = Somar(numeroAtual, new FracaoLong(1)))
                {
                    var resultadoAtual = CalcularEquacao(equacao, numeroAtual);
                    if (intervaloEncontrado == null &&
                        ((resultadoAnterior.MenorQue(fracaoZero) && resultadoAtual.MaiorOuIgualQue(fracaoZero) || (resultadoAnterior.MaiorQue(fracaoZero) && resultadoAtual.MenorOuIgualQue(fracaoZero)))))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<Fracao<long>>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
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