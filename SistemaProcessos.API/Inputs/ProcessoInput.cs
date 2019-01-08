using SistemaProcessos.Services.Interfaces;
using System;

namespace SistemaProcessos.API.Inputs
{
    public class ProcessoInput
    {
        public string NumProcesso { get; set; }
        public string Estado { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Ativo { get; set; }
        public Guid IdEmpresa { get; set; }

        private readonly IEmpresaService _empresaService;

        public ProcessoInput(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        private bool DataInicioEhValida()
        {
            return DateTime.Now >= DataInicio;
        }

        private bool ValorEhValido()
        {
            return Valor > 0;
        }

        private bool EmpresaEhValida()
        {
            return _empresaService.ObterPorId(IdEmpresa) != null;
        }

        public bool EhValido()
        {
            return DataInicioEhValida() && ValorEhValido() && EmpresaEhValida();
        }
    }
}
