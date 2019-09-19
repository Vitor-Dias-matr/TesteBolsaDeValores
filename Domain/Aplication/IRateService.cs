using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain.Aplication
{
    public interface IRateService
    {
        Trade ComprarAcao(string symbol, int quantidade);
        Trade VenderAcao(string symbol, int quantidade);
        List<Rate> ListagemDeCotacaoAtual(string symbol,  DateTime dateTime);
    }
}
