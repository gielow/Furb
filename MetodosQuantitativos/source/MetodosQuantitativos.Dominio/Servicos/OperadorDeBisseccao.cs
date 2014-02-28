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
        
        public Fracao<T> Calcular(EquacaoFracao<T> equacao, Fracao<T> numeroMenor, Fracao<T> numeroMaior)
        {
            var media = operadorDeFracoes.Media(numeroMenor, numeroMaior);
            throw new System.NotImplementedException();
        }
    }
}