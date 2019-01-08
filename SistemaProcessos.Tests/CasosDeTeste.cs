using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaProcessos.Business.Interfaces;
using SistemaProcessos.Services.Implementacao;
using System;
using System.Linq;

namespace SistemaProcessos.Tests
{
    [TestClass]
    public class CasosDeTeste
    {
        public CasosDeTeste() {
        }

        [TestMethod]
        public void RetornarSomaDosProcessosAtivos_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            Assert.IsTrue(1087000 == pb.RetornarSomaDosProcessosAtivos());
        }

        [TestMethod]
        public void RetornarMediaDosProcessosPorEmpresaEEstado_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            Assert.IsTrue(110000 == pb.RetornarMediaDosProcessosPorEmpresaEEstado(Guid.Parse("DC43D643-A162-4673-B57C-7EE4F5E3599C"), "Rio de Janeiro"));
        }

        [TestMethod]
        public void RetornarQuantidadeProcessosAcimaDeUmValor_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            Assert.IsTrue(2 == pb.RetornarQuantidadeProcessosAcimaDeUmValor(100000));
        }

        [TestMethod]
        public void RetornarProcessosPorMesAno_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            var retorno = pb.RetornarProcessosPorMesAno(7, 2007);
            Assert.IsTrue(retorno.Select(p => p.NumProcesso).Contains("00010TRABAM") && retorno.Count() == 1);
        }

        [TestMethod]
        public void RetornarProcessosNoMesmoEstadoDaEmpresa_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            var retorno = pb.RetornarProcessosNoMesmoEstadoDaEmpresa("00000000001");
            Assert.IsTrue(retorno.Select(p => p.NumProcesso).Contains("00001CIVELRJ") && retorno.Select(p => p.NumProcesso).Contains("00004CIVELRJ") && retorno.Count() == 2);
        }

        [TestMethod]
        public void RetornarProcessosPorSiglaLike_Sucesso()
        {
            var mockProcessoBusiness = new Mock<IProcessoBusiness>();
            ProcessoService pb = new ProcessoService(mockProcessoBusiness.Object);
            var retorno = pb.RetornarProcessosPorSiglaLike("TRAB");
            Assert.IsTrue(retorno.Select(p => p.NumProcesso).Contains("00003TRABMG") && retorno.Select(p => p.NumProcesso).Contains("00010TRABAM") && retorno.Count() == 2);
        }
    }
}
