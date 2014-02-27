﻿
namespace MetodosQuantitativos.Dominio.Entidades
{
    public class FracaoLong :Fracao<long>
    {
        public FracaoLong(long numerador, long denominador) : base(numerador, denominador)
        {
        }

        public FracaoLong(long numerado) : base(numerado, 1)
        {
        }
    }
}