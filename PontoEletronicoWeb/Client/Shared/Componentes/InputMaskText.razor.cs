using Microsoft.AspNetCore.Components;
using PontoEletronicoWeb.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Shared.Componentes
{
    public class InputMaskTextBase : ComponentBase
    {
        #region Parametros
        [Parameter]
        public TipoMascara TipoMascara { get; set; } = TipoMascara.Texto;

        [Parameter]
        public string Class { get; set; } = "form-control form-control-sm";

        [Parameter]
        public string Type { get; set; } = "text";

        [Parameter]
        public string Placeholder { get; set; } = string.Empty;

        [Parameter]
        public string TextoDigitado
        {
            get => textoDigitado;
            set
            {
                if (textoDigitado == value)
                    return;

                textoDigitado = value;

                TextoDigitadoChanged.InvokeAsync(textoDigitado);
            }
        }
        private string textoDigitado;

        [Parameter]
        public EventCallback<string> TextoDigitadoChanged { get; set; }

        [Parameter]
        public bool RequiredInput { get; set; }

        [Parameter]
        public int MaxLength { get; set; }

        #endregion

        #region Rotinas

        public void Key(ChangeEventArgs e)
        {
            if (TipoMascara.Telefone == TipoMascara)
                TextoDigitado = MascaraTelefone(e.Value.ToString());
            else if (TipoMascara.CPFCNPJ == TipoMascara)
                TextoDigitado = MascaraCnpjCpf(e.Value.ToString());
            else if (TipoMascara.RG == TipoMascara)
                TextoDigitado = MascaraRG(e.Value.ToString());
            else if (TipoMascara.PisPasep == TipoMascara)
                TextoDigitado = MascaraPisPasep(e.Value.ToString());

            StateHasChanged();
        }

        #region Telefone
        public string MascaraTelefone(string Texto)
        {
            if (string.IsNullOrEmpty(Texto))
                return string.Empty;

            string limpa = Texto
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace(" ", string.Empty)
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);

            string telMask = string.Empty;

            foreach (var ch in limpa)
            {
                if (telMask.Length.Equals(0))
                    telMask += "(";
                if (telMask.Length.Equals(3))
                    telMask += ") ";
                if (limpa.Length <= 10)
                {
                    if (telMask.Length.Equals(9))
                        telMask += "-";
                }
                else
                {
                    if (telMask.Length.Equals(6))
                        telMask += ".";
                    if (telMask.Length.Equals(11))
                        telMask += "-";
                }

                telMask += ch;
            }
            return telMask;
        }
        #endregion

        #region Pis/pasep
        private static string MascaraPisPasep(string cpf)
        {
            string limpa = cpf.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
            string pisPasepMask = string.Empty;

            foreach (var ch in limpa)
            {
                if (pisPasepMask.Length.Equals(3) || pisPasepMask.Length.Equals(9))
                    pisPasepMask += ".";
                if (pisPasepMask.Length.Equals(12))
                    pisPasepMask += "-";

                pisPasepMask += ch;
            }
            return pisPasepMask;
        }
        #endregion

        #region CNPJ / CPF
        public static string MascaraCnpjCpf(string cnpjCpf)
        {
            string limpa = cnpjCpf.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
            string cpfCnpjMask = string.Empty;

            if (limpa.Length > 11)
                cpfCnpjMask = MascaraCnpj(limpa);
            else
                cpfCnpjMask = MascaraCpf(limpa);

            return cpfCnpjMask;
        }

        private static string MascaraCpf(string cpf)
        {
            string limpa = cpf.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
            string cpfMask = string.Empty;

            foreach (var ch in limpa)
            {
                if (cpfMask.Length.Equals(3) || cpfMask.Length.Equals(7))
                    cpfMask += ".";
                if (cpfMask.Length.Equals(11))
                    cpfMask += "-";

                cpfMask += ch;
            }
            return cpfMask;
        }

        private static string MascaraCnpj(string cnpj)
        {
            string limpa = cnpj.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
            string cpfMask = string.Empty;

            foreach (var ch in limpa)
            {
                if (cpfMask.Length.Equals(2) || cpfMask.Length.Equals(6))
                    cpfMask += ".";
                if (cpfMask.Length.Equals(10))
                    cpfMask += "/";
                if (cpfMask.Length.Equals(15))
                    cpfMask += "-";

                cpfMask += ch;
            }
            return cpfMask;
        }
        #endregion

        #region RG
        public static string MascaraRG(string rg)
        {
            string limpa = rg.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
            string rgMask = string.Empty;

            foreach (var ch in limpa)
            {
                if (rgMask.Length.Equals(2) || rgMask.Length.Equals(6))
                    rgMask += ".";
                if (rgMask.Length.Equals(10))
                    rgMask += "-";

                rgMask += ch;
            }

            return rgMask;
        }
        #endregion

        #endregion

    }
}
