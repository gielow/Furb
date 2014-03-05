﻿using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeBisseccao<T> where T : struct 
    {
        private readonly OperadorDeEquacoesComFracao<T> operadorDeEquacoes;
        private readonly IOperadorDeFracoes<T> operadorDeFracoes;

        public OperadorDeBisseccao(OperadorDeEquacoesComFracao<T> operadorDeEquacoes, IOperadorDeFracoes<T> operadorDeFracoes)
        {
            this.operadorDeEquacoes = operadorDeEquacoes;
            this.operadorDeFracoes = operadorDeFracoes;
        }
        
        public Fracao<T> Calcular(EquacaoFracao<T> equacao, Fracao<T> numeroMenor, Fracao<T> numeroMaior, Fracao<T> erroMinimo)
        {
            var fracaoZero = operadorDeFracoes.ValorDefault();
            var mediaAnterior = operadorDeFracoes.Media(numeroMenor, numeroMaior);
            
            var media = operadorDeFracoes.Media(numeroMenor, numeroMaior);
            var resultadoNumeroMenor = operadorDeEquacoes.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = operadorDeEquacoes.Calcular(equacao, numeroMaior);
            var resultadoMedia = operadorDeEquacoes.Calcular(equacao, media);

            Fracao<T> erro;
            do
            {
                if (operadorDeFracoes.Comparar(resultadoMedia, resultadoNumeroMenor) == 1 && operadorDeFracoes.Comparar(resultadoMedia, fracaoZero) == -1)
                    numeroMenor = media;
                if (operadorDeFracoes.Comparar(resultadoMedia, resultadoNumeroMaior) == -1 && operadorDeFracoes.Comparar(resultadoMedia, fracaoZero) == 1)
                    numeroMaior = media;

                media = operadorDeFracoes.Media(numeroMenor, numeroMaior);
                resultadoNumeroMenor = operadorDeEquacoes.Calcular(equacao, numeroMenor);
                resultadoNumeroMaior = operadorDeEquacoes.Calcular(equacao, numeroMaior);
                resultadoMedia = operadorDeEquacoes.Calcular(equacao, media);

                erro = operadorDeFracoes.Dividir(operadorDeFracoes.Subtrair(media, mediaAnterior), mediaAnterior);
                if (operadorDeFracoes.Comparar(erro, fracaoZero) == -1)
                    erro = operadorDeFracoes.Multiplicar(erro, -1);
                mediaAnterior = media;

            } while (operadorDeFracoes.Comparar(erro, erroMinimo) == 1);

            return media;
        }
    }
}