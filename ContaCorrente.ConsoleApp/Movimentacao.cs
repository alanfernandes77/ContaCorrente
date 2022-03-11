using System;

namespace ContaCorrente.ConsoleApp
{
    internal class Movimentacao
    {
        public decimal Valor;
        public string Tipo;
        public string Operacao;

        public string Format()
        {
            string format = "";
            switch (Tipo)
            {
                case "Credito":
                    Console.ForegroundColor = ConsoleColor.Green;
                    format = $"[↑] Tipo: Crédito | Valor: {Valor:F2} ({Operacao})";
                    break;

                case "Debito":
                    Console.ForegroundColor = ConsoleColor.Red;
                    format = $"[↓] Tipo: Débito | Valor: {Valor:F2} ({Operacao})";
                    break;
            }
            return format;
        }
    }
}