using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeEquacoesComFracao<T> where T : struct 
    {
        private readonly IOperadorDeFracoes<T> operadorDeFracoes;

        public OperadorDeEquacoesComFracao(IOperadorDeFracoes<T> operadorDeFracoes)
        {
            this.operadorDeFracoes = operadorDeFracoes;
        }

        public Fracao<T> Calcular(EquacaoFracao<T> equacao, Fracao<T> valorDeX)
        {
            var resultado = operadorDeFracoes.ValorDefault();
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var resultP = operadorDeFracoes.Potenciar(valorDeX, elementoEquacao.Expoente);
                var resultM = operadorDeFracoes.Multiplicar(elementoEquacao.Coeficiente, resultP);
                resultado = operadorDeFracoes.Somar(resultado, resultM);
            }
            return resultado;
        }
    }
}
