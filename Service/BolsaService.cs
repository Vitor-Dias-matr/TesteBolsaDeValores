using Domain.Aplication;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BolsaService : IRateService
    {
        private readonly IRateRepository _bolsaRepository;

        public BolsaService(IRateRepository repo)
        {
            this._bolsaRepository = repo;
        }


        public Trade VenderAcao(string symbol, int quantidade)
        {
            return _bolsaRepository.Query().OrderByDescending(p => p.Timestamp).Where(p => p.Symbol.ToLower() == symbol.ToLower()).Select(p => new Trade { Action = "SELL", NoOfShares = quantidade, Symbol = symbol, Price = p.Rates * quantidade }).FirstOrDefault();
        }

        public Trade ComprarAcao(string symbol, int quantidade)
        {
            return _bolsaRepository.Query().OrderByDescending(p => p.Timestamp).Where(p => p.Symbol.ToLower() == symbol.ToLower()).Select(p => new Trade { Action = "BUY", NoOfShares = quantidade, Symbol = symbol, Price = p.Rates * quantidade }).FirstOrDefault();
        }

        public List<Rate> ListagemDeCotacaoAtual()
        {
             return _bolsaRepository.Query().OrderBy(p => p.Symbol).ThenByDescending(p => p.Timestamp).GroupBy(p => p.Symbol)
                .Select(p => new Rate
                {
                    IdRate = p.First().IdRate,
                    Symbol = p.First().Symbol,
                    Rates = p.First().Rates,
                    Timestamp = p.First().Timestamp
                }
            ).ToList();
            
        }
    }
}
