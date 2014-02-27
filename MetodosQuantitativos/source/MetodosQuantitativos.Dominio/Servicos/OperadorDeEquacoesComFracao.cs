using System;
using System.Linq;
using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeEquacoesComFracao
    {
        private OperadorDeFracoesInt operadorDeFracoes;

        public OperadorDeEquacoesComFracao()
        {
            this.operadorDeFracoes = ope
        }

        public Fracao<T> Calcular<T>(EquacaoFracao<T> equacao, Fracao<T> valorDeX) where T : struct
        {
            return equacao.Elementos[0].Coeficiente;
            //return equacao.Elementos.Sum(elementoDaEquacao => elementoDaEquacao.Coeficiente*(int) Math.Pow(valorDeX, elementoDaEquacao.Expoente));
        }
    }
}
