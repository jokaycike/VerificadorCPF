using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace VerificadorCPF.API
{
    public class DadosCPF
    {
        public DateTime? Data { get; set; }
        public bool? Valido { get; set; }
        public string? Mensagem { get; set;}
        public string? Estado { get; set; }
        public string? CPF { get; set; }

        public static DadosCPF TodaVerificacao(string CPF) 
        { 
            DadosCPF OBJ = new DadosCPF();
            RetornoResposta NullOk = NullVerificacao(CPF);
            if (NullOk.Valido == false)
            {
                OBJ.Valido = NullOk.Valido;
                OBJ.Mensagem = NullOk.Mensagem;
                return OBJ;
            }
            RetornoResposta TamanhoOk = TamanhoVerificacao(CPF);
            if(TamanhoOk.Valido == false)
            {
                OBJ.Valido = TamanhoOk.Valido;
                OBJ.Mensagem = TamanhoOk.Mensagem;
                return OBJ;
            }
            OBJ.Mensagem = "oiii";
            return OBJ;
        }
        private static RetornoResposta NullVerificacao(string CPF)
        {
            if(CPF == null)
            {
                return new RetornoResposta
                {
                    Valido = false,
                    Mensagem = "Campo não preenchido"
                };
            }
            else
            {
                return new RetornoResposta
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
        }
        private static RetornoResposta TamanhoVerificacao(string CPF)
        {
            if(CPF.Length >= 11 && CPF.Length <= 14)
            {
                return new RetornoResposta
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
            else
            {
                return new RetornoResposta
                {
                    Valido = false,
                    Mensagem = "Tamanho inválido"
                };
            }
        }


    }
}
