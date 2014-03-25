namespace MetodosQuantitativos.Operacoes.Biseccao
{
    public class IntervaloBiseccao<T>
    {
        public IntervaloBiseccao(T menor, T resultadoMenor, T maior, T resultadoMaior)
        {
            Menor = menor;
            ResultadoMenor = resultadoMenor;
            Maior = maior;
            ResultadoMaior = resultadoMaior;
        }

        public T Menor { get; set; }
        public T ResultadoMenor { get; set; }
        public T Maior { get; set; }
        public T ResultadoMaior { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}", Menor, Maior);
        }
    }
}