using MetodosQuantitativos.Dominio.Entidades;
using System;
using MetodosQuantitativos.Dominio.Entidades.Biseccao;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Extencoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesInt : IOperadorDeFracoes<int>
    {
        public Fracao<int> Simplificar(Fracao<int> fracao)
        {
            var fracaoResultado = new Fracao<int>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new FracaoInt(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            if (fracaoResultado.Numerador < 0 && fracaoResultado.Denominador < 0)
            {
                fracaoResultado = new FracaoInt(fracaoResultado.Numerador * -1, fracaoResultado.Denominador * -1);
            }
            return fracaoResultado;
        }

        public Fracao<int> Somar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<int> SomarDenominadorDiferente(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new FracaoInt(numerador, denominador);
        }

        private static Fracao<int> SomarDenominadorIgual(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<int>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<int> Subtrair(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<int> SubtrairDenominadorIgual(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<int>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<int> SubtrairDenominadorDiferente(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<int>(numerador, denominador);
        }

        public Fracao<int> Multiplicar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(MultiplicarSemSimplificar(fracao1, fracao2));
        }

        public Fracao<int> Multiplicar(Fracao<int> fracao1, int multiplicador)
        {
            return Multiplicar(fracao1, new FracaoInt(multiplicador));
        }

        public Fracao<int> MultiplicarSemSimplificar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return new Fracao<int>(fracao1.Numerador * fracao2.Numerador, fracao1.Denominador * fracao2.Denominador);
        }

        public Fracao<int> Dividir(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(new Fracao<int>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<int> Potenciar(Fracao<int> fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoInt(1);
            }
            var fracaoResultado = new Fracao<int>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<int> Raiz(Fracao<int> fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracao<int>();
            equacaoBiseccaoNumerador.AdicionarElemento(new ElementoEquacaoFracao<int>(new Fracao<int>(1, 1), raiz));
            equacaoBiseccaoNumerador.AdicionarElemento(new ElementoEquacaoFracao<int>(new Fracao<int>(fracao.Numerador * -1, 1), 0));
            var resultadoBiseccaoNumerador = Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracao<int>();
            equacaoBiseccaoDenominador.AdicionarElemento(new ElementoEquacaoFracao<int>(new Fracao<int>(1, 1), raiz));
            equacaoBiseccaoDenominador.AdicionarElemento(new ElementoEquacaoFracao<int>(new Fracao<int>(fracao.Denominador * -1, 1), 0));
            var resultadoBiseccaoDenominador = Bisseccao(equacaoBiseccaoDenominador);

            return Dividir(resultadoBiseccaoNumerador, resultadoBiseccaoDenominador);
        }
        
        public Fracao<int> Media(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var somaDasDuasFracoes = Somar(fracao1, fracao2);
            return Dividir(somaDasDuasFracoes, new FracaoInt(2, 1));
        }

        public int Comparar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var fracao1Comparar = MultiplicarSemSimplificar(fracao1, new FracaoInt(fracao2.Denominador, fracao2.Denominador));
            var fracao2Comparar = MultiplicarSemSimplificar(fracao2, new FracaoInt(fracao1.Denominador, fracao1.Denominador));
            if (fracao1Comparar.Numerador > fracao2Comparar.Numerador)
                return 1;
            if (fracao1Comparar.Numerador < fracao2Comparar.Numerador)
                return -1;
            return 0;
        }

        public Fracao<int> CalcularEquacao(EquacaoFracao<int> equacao, Fracao<int> valorDeX)
        {
            Fracao<int> resultado = new FracaoInt(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var resultP = Potenciar(valorDeX, elementoEquacao.Expoente);
                var resultM = Multiplicar(elementoEquacao.Coeficiente, resultP);
                resultado = Somar(resultado, resultM);
            }
            return resultado;
        }

        public Fracao<int> Bisseccao(EquacaoFracao<int> equacao)
        {
            return Bisseccao(equacao, new FracaoInt(1, 100));
        }

        public Fracao<int> Bisseccao(EquacaoFracao<int> equacao, Fracao<int> erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public Fracao<int> Bisseccao(EquacaoFracao<int> equacao, Fracao<int> erroMinimo, IntervaloBiseccao<Fracao<int>> valoresEntradaBiseccao)
        {
            var fracaoZero = new FracaoInt(0);

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
            Fracao<int> erro;

            ImprimirLinhaBiseccao("X1", "XM", "X2", "F(X1)", "F(XM)", "F(X2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, "-");
            do
            {
                if (
                    ((Comparar(resultadoNumeroMenor, fracaoZero) == -1 && Comparar(resultadoNumeroMenor, resultadoMedia) == -1) && Comparar(resultadoMedia, fracaoZero) == -1) ||
                    ((Comparar(resultadoNumeroMenor, fracaoZero) == 1 && Comparar(resultadoNumeroMenor, resultadoMedia) == 1) && Comparar(resultadoMedia, fracaoZero) == 1))
                    numeroMenor = media;
                if (
                    ((Comparar(resultadoNumeroMaior, fracaoZero) == 1 && Comparar(resultadoNumeroMaior, resultadoMedia) == 1) && Comparar(resultadoMedia, fracaoZero) == 1) ||
                    ((Comparar(resultadoNumeroMaior, fracaoZero) == -1 && Comparar(resultadoNumeroMaior, resultadoMedia) == -1) && Comparar(resultadoMedia, fracaoZero) == -1))
                    numeroMaior = media;

                media = Media(numeroMenor, numeroMaior);
                resultadoNumeroMenor = CalcularEquacao(equacao, numeroMenor);
                resultadoNumeroMaior = CalcularEquacao(equacao, numeroMaior);
                resultadoMedia = CalcularEquacao(equacao, media);

                erro = Dividir(Subtrair(media, mediaAnterior), mediaAnterior).TransformarParaPositivo();
                mediaAnterior = media;
                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);

            } while (Comparar(erro, erroMinimo) == 1);

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

        public IntervaloBiseccao<Fracao<int>> ObterValoresBiseccao(EquacaoFracao<int> equacao)
        {
            Console.WriteLine("Equacao: " + equacao); 
            var fracaoZero = new FracaoInt(0);
            IntervaloBiseccao<Fracao<int>> intervaloEncontrado = null;
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

                Fracao<int> valorInicial = new FracaoInt(numeroInicial);
                Fracao<int> valorFinal = new FracaoInt(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = CalcularEquacao(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual.MenorOuIgualQue(valorFinal); numeroAtual = Somar(numeroAtual, new FracaoInt(1)))
                {
                    var resultadoAtual = CalcularEquacao(equacao, numeroAtual);
                    if (intervaloEncontrado == null && 
                        ((resultadoAnterior.MenorQue(fracaoZero) && resultadoAtual.MaiorOuIgualQue(fracaoZero) || (resultadoAnterior.MaiorQue(fracaoZero) && resultadoAtual.MenorOuIgualQue(fracaoZero)))))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<Fracao<int>>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
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