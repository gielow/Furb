using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades;
using System;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

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
                    fracaoResultado = new Fracao<int>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
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
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new Fracao<int>(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }

        public Fracao<int> ValorDefault()
        {
            return new FracaoInt(0);
        }

        public Fracao<int> CriarFracao(int numerador, int denominador)
        {
            return new FracaoInt(numerador, denominador);
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

        public int BuscarMenorNumeroParaZerarEquacao(EquacaoFracao<int> equacao)
        {
            var fracaoZero = new FracaoInt(0);
            var numeroTestado = 0;
            var resultado = CalcularEquacao(equacao, new FracaoInt(numeroTestado));
            var ultimoNumeroTestado = numeroTestado;
            var ultimoResultado = resultado;
            

            while ((Comparar(ultimoResultado, fracaoZero) == -1 && Comparar(resultado, fracaoZero) == -1) ||
                   (Comparar(ultimoResultado, fracaoZero) == 1 && Comparar(resultado, fracaoZero) == 1))
            {
                ultimoNumeroTestado = numeroTestado;
                ultimoResultado = resultado;

                if (Comparar(resultado, fracaoZero) == 0)
                {
                    return numeroTestado;
                }
                if (Comparar(resultado, fracaoZero) == 1)
                {
                    numeroTestado--;
                }
                else if (Comparar(resultado, fracaoZero) == -1)
                {
                    numeroTestado++;
                }
                resultado = CalcularEquacao(equacao, new FracaoInt(numeroTestado));
            }
            return ultimoNumeroTestado;
        }

        public int BuscarMenorNumeroParaZerarEquacao(EquacaoFracao<int> equacao, EntradaBisseccaoDTO entradaBisseccao)
        {
            //var zero = new FracaoInt(0);
            //var media = Media(entradaBisseccao.ValorMinimo, entradaBisseccao.ValorMaximo);
            var resultadoMin = CalcularEquacao(equacao, entradaBisseccao.ValorMinimo);
            var resultadoMax = CalcularEquacao(equacao, entradaBisseccao.ValorMaximo);
            //var resultadoMed = CalcularEquacao(equacao, media);
            var diferencaMin = resultadoMin.Numerador;
            if (diferencaMin < 0)
                diferencaMin *= -1;

            var diferencaMax = resultadoMax.Numerador;
            if (diferencaMax < 0)
                diferencaMax *= -1;

            var media = (entradaBisseccao.ValorMinimo.Numerador + entradaBisseccao.ValorMaximo.Numerador) / 2;
            if (diferencaMax < diferencaMin)
            {
                var newEntradaBisseccao = new EntradaBisseccaoDTO(entradaBisseccao.ValorMaximo, new FracaoInt(media));
                return BuscarMenorNumeroParaZerarEquacao(equacao, newEntradaBisseccao);
            }
            else
            {
                var newEntradaBisseccao = new EntradaBisseccaoDTO(entradaBisseccao.ValorMinimo, new FracaoInt(media));
                return BuscarMenorNumeroParaZerarEquacao(equacao, newEntradaBisseccao);
                
            }

        }

        public class EntradaBisseccaoDTO
        {
            public EntradaBisseccaoDTO(Fracao<int> valorMinimo, Fracao<int> valorMaximo)
            {
                ValorMinimo = valorMinimo;
                ValorMaximo = valorMaximo;
            }

            public Fracao<int> ValorMinimo { get; set; }
            public Fracao<int> ValorMaximo { get; set; } 
        }

        public object BuscarMaiorNumeroParaZerarEquacao(EquacaoFracao<int> equacao)
        {
            return new FracaoInt(0);
        }

        public Fracao<int> Bisseccao(EquacaoFracao<int> equacao, Fracao<int> erroMinimo)
        {
            Fracao<int> fracaoZero = new FracaoInt(0);
            Fracao<int> numeroMenor = new FracaoInt(0);
            Fracao<int> numeroMaior = new FracaoInt(0);
            var mediaAnterior = Media(numeroMenor, numeroMaior);

            var media = Media(numeroMenor, numeroMaior);
            var resultadoNumeroMenor = CalcularEquacao(equacao, numeroMenor);
            var resultadoNumeroMaior = CalcularEquacao(equacao, numeroMaior);
            var resultadoMedia = CalcularEquacao(equacao, media);

            Fracao<int> erro;
            do
            {
                if (Comparar(resultadoMedia, resultadoNumeroMenor) == 1 && Comparar(resultadoMedia, fracaoZero) == -1)
                    numeroMenor = media;
                if (Comparar(resultadoMedia, resultadoNumeroMaior) == -1 && Comparar(resultadoMedia, fracaoZero) == 1)
                    numeroMaior = media;

                media = Media(numeroMenor, numeroMaior);
                resultadoNumeroMenor = CalcularEquacao(equacao, numeroMenor);
                resultadoNumeroMaior = CalcularEquacao(equacao, numeroMaior);
                resultadoMedia = CalcularEquacao(equacao, media);

                erro = Dividir(Subtrair(media, mediaAnterior), mediaAnterior);
                if (Comparar(erro, fracaoZero) == -1)
                    erro = Multiplicar(erro, -1);
                mediaAnterior = media;

            } while (Comparar(erro, erroMinimo) == 1);

            return media;
        }
    }
}