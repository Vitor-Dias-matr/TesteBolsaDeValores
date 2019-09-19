using Domain.Aplication;
using Domain.Model;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class BolsaDeValores
    {
        private readonly IRateService _rateService;
        private readonly Mock<IRateRepository> _rateRepository = new Mock<IRateRepository>();

        public BolsaDeValores()
        {
            _rateService = new BolsaService(_rateRepository.Object);
        }

        #region Mock
        public List<Rate> MockSimulater()
        {
            var lista = new List<Rate>();

            lista.Add(new Rate
            {
                IdRate = 1,
                Symbol = "CBI",
                Rates = 2,
                Timestamp = new DateTime(2018, 1, 1, 0, 0, 0)
            });
            lista.Add(new Rate
            {
                IdRate = 2,
                Symbol = "CBI",
                Rates = 3,
                Timestamp = new DateTime(2018, 1, 2, 0, 0, 0)
            });
            lista.Add(new Rate
            {
                IdRate = 3,
                Symbol = "LST",
                Rates = 3,
                Timestamp = new DateTime(2019,1,1,0,0,0)
            });
            lista.Add(new Rate
            {
                IdRate = 4,
                Symbol = "LST",
                Rates = 3,
                Timestamp = new DateTime(2019, 2, 2, 0, 0, 0)
            });

            return lista;
        }
        #endregion

        [Theory]
        [InlineData ("CBI",150,300)]
        [InlineData ("LST", 30,90)]
        public void TestaCompraDeVenda (string symbol, int quantidade,  decimal valorEsperado) 
        {
            //Arrange
            _rateRepository.Setup(p => p.Query()).Returns(MockSimulater());

            //Act

            var lista = _rateService.ComprarAcao(symbol,quantidade);

            //Acert
            Assert.Equal(valorEsperado,lista.Price);
        }
        [Theory]
        [InlineData ("CBI",150,300)]
        [InlineData ("LST",200,600)]
        public void TestaVendaDeAcao(string symbol, int quantidade, decimal valorEsperado)
        {
            //Arrange 
            _rateRepository.Setup(p => p.Query()).Returns(MockSimulater());

            //Act
            var lista = _rateService.VenderAcao(symbol, quantidade);

            //Acert 
            Assert.Equal(valorEsperado, lista.Price);
        }


        public static class DatasParametro
        {
            public static List<DateTime> Datas()
            {
                var lista = new List<DateTime> {
                    new DateTime(2018,01,01),
                    new DateTime(2018,01,02),
                    new DateTime(2019,01,01),
                    new DateTime(2019,02,02),
                };
                return lista;
            }
        }


        [Theory]
        [InlineData ("CBI",0, 2)]
        [InlineData("CBI", 1, 3)]
        [InlineData("LST", 2, 3)]
        [InlineData("LST", 3, 3)]
        public void ListagemDeCotacaoAtual(string symbol, int data, int rate)
        {
            //Arrange 
            var dataParaPesquisa = DatasParametro.Datas()[data];
            _rateRepository.Setup(p => p.Query()).Returns(MockSimulater());

            //Act 

            var dataDaCotacao = _rateService.ListagemDeCotacaoAtual(symbol,)

            //Acert

            Assert.Equal(rate, dataDaCotacao.Count);
        }


    }
}