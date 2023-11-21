﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.RegularExpressions;

namespace VerificadorCPF.API
{
    public class DadosCPF
    {
        public DateTime? Data { get; set; }
        public bool? Valido { get; set; }
        public string? Mensagem { get; set; }
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
            if (TamanhoOk.Valido == false)
            {
                OBJ.Valido = TamanhoOk.Valido;
                OBJ.Mensagem = TamanhoOk.Mensagem;
                return OBJ;
            }

            RetornoResposta ApenasOK = ApenasVerificacao(CPF);
            if (ApenasOK.Valido == false)
            {
                OBJ.Valido = ApenasOK.Valido;
                OBJ.Mensagem = ApenasOK.Mensagem;
                return OBJ;
            }

            RetornoResposta LimpaOK = LimpaVerificacao(CPF);

            OBJ.Mensagem = "oiii";
            return OBJ;
        }

        private static RetornoResposta NullVerificacao(string CPF)
        {
            if (CPF == null)
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
            if (CPF.Length == 11 || CPF.Length == 14)
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

        private static RetornoResposta ApenasVerificacao(string CPF)
        {
            if (Regex.IsMatch(CPF, @"^\d{11}$|^\d{14}$|^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
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
                    Mensagem = "Confira se não está enserindo letra ou simbolos ou esta colocando a pontuação no lugar errado"
                };
            }

        }

        private static RetornoResposta LimpaVerificacao(string CPF)
        {
            string CPFLimpo = "";

            foreach (char i in CPF)
            {
                try
                {
                    CPFLimpo += Convert.ToString(Convert.ToInt32(i));
                }
                catch
                {
                }
            }
            return new RetornoResposta
            {
                Valido = true,
                Mensagem = CPFLimpo
            };
        }

        private static RetornoResposta ContaVerificacao(string CPF)
        {
            return new RetornoResposta
            {
                Valido = true,
                Mensagem = CPF
            };
        }
    }
}
