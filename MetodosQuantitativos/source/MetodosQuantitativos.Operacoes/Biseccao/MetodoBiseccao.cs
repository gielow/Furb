using System;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Biseccao
{
    public class MetodoBiseccao
    {
        public static FracaoInt Bisseccao(EquacaoFracaoInt equacao)
        {
            return Bisseccao(equacao, new FracaoInt(1, 1000));
        }

        public static FracaoInt Bisseccao(EquacaoFracaoInt equacao, FracaoInt erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public static FracaoInt Bisseccao(EquacaoFracaoInt equacao, FracaoInt erroMinimo, IntervaloBiseccao<FracaoInt> valoresEntradaBiseccao)
        {
            if (valoresEntradaBiseccao.ResultadoMenor == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Menor);
                return valoresEntradaBiseccao.Menor;
            }
            if (valoresEntradaBiseccao.ResultadoMaior == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Maior);
                return valoresEntradaBiseccao.Maior;
            }

            var numeroMenor = valoresEntradaBiseccao.Menor;
            var numeroMaior = valoresEntradaBiseccao.Maior;
            var mediaAnterior = (numeroMenor + numeroMaior) / 2;

            var media = (numeroMenor + numeroMaior) / 2;
            var resultadoNumeroMenor = EquacaoFracaoInt.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = EquacaoFracaoInt.Calcular(equacao, numeroMaior);
            var resultadoMedia = EquacaoFracaoInt.Calcular(equacao, media);
            FracaoInt erro;

            ImprimirLinhaBiseccao("X1", "XM", "X2", "F(X1)", "F(XM)", "F(X2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, "-");
            do
            {
                if (((resultadoNumeroMenor < 0 && resultadoNumeroMenor < resultadoMedia) && resultadoMedia < 0) || ((resultadoNumeroMenor > 0 && resultadoNumeroMenor > resultadoMedia) && resultadoMedia > 0))
                    numeroMenor = media;
                if (((resultadoNumeroMaior > 0 && resultadoNumeroMaior > resultadoMedia) && resultadoMedia > 0) || ((resultadoNumeroMaior < 0 && resultadoNumeroMaior < resultadoMedia) && resultadoMedia < 0))
                    numeroMaior = media;

                media = (numeroMenor + numeroMaior) / 2;
                resultadoNumeroMenor = EquacaoFracaoInt.Calcular(equacao, numeroMenor);
                resultadoNumeroMaior = EquacaoFracaoInt.Calcular(equacao, numeroMaior);
                resultadoMedia = EquacaoFracaoInt.Calcular(equacao, media);

                erro = ((media - mediaAnterior) / mediaAnterior).TransformarParaPositivo();
                mediaAnterior = media;
                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);

            } while (erro > erroMinimo);

            Console.WriteLine("Resultado da Bisecção: " + media);
            Console.WriteLine();
            Console.WriteLine();
            return media;
        }

        public static IntervaloBiseccao<FracaoInt> ObterValoresBiseccao(EquacaoFracaoInt equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            IntervaloBiseccao<FracaoInt> intervaloEncontrado = null;
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

                var valorInicial = new FracaoInt(numeroInicial);
                var valorFinal = new FracaoInt(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = EquacaoFracaoInt.Calcular(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual < valorFinal; numeroAtual++)
                {
                    var resultadoAtual = EquacaoFracaoInt.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual >= 0) || (resultadoAnterior > 0 && resultadoAtual <= 0)))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<FracaoInt>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
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

        public static FracaoLong Bisseccao(EquacaoFracaoLong equacao)
        {
            return Bisseccao(equacao, new FracaoLong(1, 1000));
        }

        public static FracaoLong Bisseccao(EquacaoFracaoLong equacao, FracaoLong erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public static FracaoLong Bisseccao(EquacaoFracaoLong equacao, FracaoLong erroMinimo, IntervaloBiseccao<FracaoLong> valoresEntradaBiseccao)
        {
            if (valoresEntradaBiseccao.ResultadoMenor == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Menor);
                return valoresEntradaBiseccao.Menor;
            }
            if (valoresEntradaBiseccao.ResultadoMaior == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Maior);
                return valoresEntradaBiseccao.Maior;
            }

            var numeroMenor = valoresEntradaBiseccao.Menor;
            var numeroMaior = valoresEntradaBiseccao.Maior;
            var mediaAnterior = (numeroMenor + numeroMaior) / 2;

            var media = (numeroMenor + numeroMaior) / 2;
            var resultadoNumeroMenor = EquacaoFracaoLong.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = EquacaoFracaoLong.Calcular(equacao, numeroMaior);
            var resultadoMedia = EquacaoFracaoLong.Calcular(equacao, media);
            FracaoLong erro;

            ImprimirLinhaBiseccao("X1", "XM", "X2", "F(X1)", "F(XM)", "F(X2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, "-");
            do
            {
                if (((resultadoNumeroMenor < 0 && resultadoNumeroMenor < resultadoMedia) && resultadoMedia < 0) || ((resultadoNumeroMenor > 0 && resultadoNumeroMenor > resultadoMedia) && resultadoMedia > 0))
                    numeroMenor = media;
                if (((resultadoNumeroMaior > 0 && resultadoNumeroMaior > resultadoMedia) && resultadoMedia > 0) || ((resultadoNumeroMaior < 0 && resultadoNumeroMaior < resultadoMedia) && resultadoMedia < 0))
                    numeroMaior = media;

                media = (numeroMenor + numeroMaior) / 2;
                resultadoNumeroMenor = EquacaoFracaoLong.Calcular(equacao, numeroMenor);
                resultadoNumeroMaior = EquacaoFracaoLong.Calcular(equacao, numeroMaior);
                resultadoMedia = EquacaoFracaoLong.Calcular(equacao, media);

                erro = ((media - mediaAnterior) / mediaAnterior).TransformarParaPositivo();
                mediaAnterior = media;
                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);

            } while (erro > erroMinimo);

            Console.WriteLine("Resultado da Bisecção: " + media);
            Console.WriteLine();
            Console.WriteLine();
            return media;
        }

        public static IntervaloBiseccao<FracaoLong> ObterValoresBiseccao(EquacaoFracaoLong equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            IntervaloBiseccao<FracaoLong> intervaloEncontrado = null;
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

                var valorInicial = new FracaoLong(numeroInicial);
                var valorFinal = new FracaoLong(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = EquacaoFracaoLong.Calcular(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual < valorFinal; numeroAtual++)
                {
                    var resultadoAtual = EquacaoFracaoLong.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual >= 0) || (resultadoAnterior > 0 && resultadoAtual <= 0)))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<FracaoLong>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
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

        public static FracaoBigInteger Bisseccao(EquacaoFracaoBigInteger equacao)
        {
            return Bisseccao(equacao, new FracaoBigInteger(1, 1000));
        }

        public static FracaoBigInteger Bisseccao(EquacaoFracaoBigInteger equacao, FracaoBigInteger erroMinimo)
        {
            var valoresEntradaBiseccao = ObterValoresBiseccao(equacao);
            return Bisseccao(equacao, erroMinimo, valoresEntradaBiseccao);
        }

        public static FracaoBigInteger Bisseccao(EquacaoFracaoBigInteger equacao, FracaoBigInteger erroMinimo, IntervaloBiseccao<FracaoBigInteger> valoresEntradaBiseccao)
        {
            if (valoresEntradaBiseccao.ResultadoMenor == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Menor);
                return valoresEntradaBiseccao.Menor;
            }
            if (valoresEntradaBiseccao.ResultadoMaior == 0)
            {
                Console.WriteLine("Resultado da Bisecção: " + valoresEntradaBiseccao.Maior);
                return valoresEntradaBiseccao.Maior;
            }

            var numeroMenor = valoresEntradaBiseccao.Menor;
            var numeroMaior = valoresEntradaBiseccao.Maior;
            var mediaAnterior = (numeroMenor + numeroMaior) / 2;

            var media = (numeroMenor + numeroMaior) / 2;
            var resultadoNumeroMenor = EquacaoFracaoBigInteger.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = EquacaoFracaoBigInteger.Calcular(equacao, numeroMaior);
            var resultadoMedia = EquacaoFracaoBigInteger.Calcular(equacao, media);
            FracaoBigInteger erro;

            ImprimirLinhaBiseccao("X1", "XM", "X2", "F(X1)", "F(XM)", "F(X2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, "-");
            do
            {
                if (((resultadoNumeroMenor < 0 && resultadoNumeroMenor < resultadoMedia) && resultadoMedia < 0) || ((resultadoNumeroMenor > 0 && resultadoNumeroMenor > resultadoMedia) && resultadoMedia > 0))
                    numeroMenor = media;
                if (((resultadoNumeroMaior > 0 && resultadoNumeroMaior > resultadoMedia) && resultadoMedia > 0) || ((resultadoNumeroMaior < 0 && resultadoNumeroMaior < resultadoMedia) && resultadoMedia < 0))
                    numeroMaior = media;

                media = (numeroMenor + numeroMaior) / 2;
                resultadoNumeroMenor = EquacaoFracaoBigInteger.Calcular(equacao, numeroMenor);
                resultadoNumeroMaior = EquacaoFracaoBigInteger.Calcular(equacao, numeroMaior);
                resultadoMedia = EquacaoFracaoBigInteger.Calcular(equacao, media);

                erro = ((media - mediaAnterior) / mediaAnterior).TransformarParaPositivo();
                mediaAnterior = media;
                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);

            } while (erro > erroMinimo);

            Console.WriteLine("Resultado da Bisecção: " + media);
            Console.WriteLine();
            Console.WriteLine();
            return media;
        }

        public static IntervaloBiseccao<FracaoBigInteger> ObterValoresBiseccao(EquacaoFracaoBigInteger equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            IntervaloBiseccao<FracaoBigInteger> intervaloEncontrado = null;
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

                var valorInicial = new FracaoBigInteger(numeroInicial);
                var valorFinal = new FracaoBigInteger(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = EquacaoFracaoBigInteger.Calcular(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual < valorFinal; numeroAtual++)
                {
                    var resultadoAtual = EquacaoFracaoBigInteger.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual >= 0) || (resultadoAnterior > 0 && resultadoAtual <= 0)))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<FracaoBigInteger>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
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

        private static void ImprimirLinhaBiseccao(object numeroMenor, object media, object numeroMaior, object resultadoNumeroMenor, object resultadoNumeroMaior, object resultadoMedia, object erro)
        {
            Console.WriteLine("{0}    |{1}    |{2}    |{3}    |{4}     |{5}    |{6}    |", numeroMenor.ToString().PadLeft(15, ' '),
                media.ToString().PadLeft(15, ' '),
                numeroMaior.ToString().PadLeft(15, ' '),
                resultadoNumeroMenor.ToString().PadLeft(15, ' '),
                resultadoNumeroMaior.ToString().PadLeft(15, ' '),
                resultadoMedia.ToString().PadLeft(15, ' '),
                erro.ToString().PadLeft(15, ' '));
        }

        private static void ImprimirLinhaBuscaValorBiseccao(object numero, object resultado)
        {
            Console.WriteLine("{0}    |{1}    |", numero.ToString().PadLeft(15, ' '), resultado.ToString().PadLeft(15, ' '));
        } 
    }
}