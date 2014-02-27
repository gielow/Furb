using System;
using System.Linq;
using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeEquacoes
    {
        public int Calcular(Equacao equacao, int valorDeX)
        {
            return equacao.Elementos.Sum(elementoDaEquacao => elementoDaEquacao.Coeficiente*(int) Math.Pow(valorDeX, elementoDaEquacao.Expoente));
        }
    }
}
