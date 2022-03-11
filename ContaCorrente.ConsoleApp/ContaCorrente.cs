using System;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public int Numero;
        public decimal Saldo;
        public bool Especial;
        public decimal Limite;
        public Movimentacao[] movimentacoes;

        private int posicao = 0;

        public void Sacar(decimal valor)
        {
            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para sacar.");
            }
            else if (Especial == true && Limite == 0)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso.");
                AdicionarMovimentacao(valor, "Debito", "Saque");
            }
            else if (valor > Limite)
            {
                Console.WriteLine("O valor inserido excede o limite disponivel para saque.");
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso.");
                AdicionarMovimentacao(valor, "Debito", "Saque");
            }
            EmitirSaldo();
            Console.WriteLine();
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            AdicionarMovimentacao(valor, "Credito", "Depósito");
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado.");
            EmitirSaldo();
            Console.WriteLine();
        }

        public void TransferirPara(ContaCorrente contaCorrente, decimal valor)
        {
            if (contaCorrente == this)
            {
                Console.WriteLine("Só é possível realizar uma transferência para uma conta diferente da sua.");
            }
            else
            {
                if (valor > Saldo)
                {
                    Console.WriteLine("Saldo insuficiente para transferir.");
                }
                else
                {
                    Saldo -= valor;
                    contaCorrente.Saldo += valor;
                    Console.WriteLine($"Transferência de R$ {valor:F2} realizada com sucesso para a conta número: {contaCorrente.Numero}");
                    AdicionarMovimentacao(valor, "Debito", $"Transferência para a conta número: {contaCorrente.Numero}");
                    contaCorrente.AdicionarMovimentacao(valor, "Credito", $"Transferência recebida da conta número {Numero}");
                }
            }
            EmitirSaldo();
            Console.WriteLine();
        }

        public void AdicionarMovimentacao(decimal valor, string tipo, string operacao)
        {
            Movimentacao movimentacao = new();
            movimentacao.Valor = valor;
            movimentacao.Tipo = tipo;
            movimentacao.Operacao = operacao;

            for (int i = 0; i < movimentacoes.Length; i++)
            {
                movimentacoes[posicao] = movimentacao;
            }
            posicao++;
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"Extrato da conta ({Numero}): ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            EmitirSaldo();
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Movimentações:");
            Console.WriteLine();
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] != null)
                {
                    Console.WriteLine(movimentacoes[i].Format());
                }
            }
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        public void ExibirConta()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------");
            Console.WriteLine($"Conta número: {Numero}");
            Console.WriteLine($"Saldo: R$ {Saldo:F2}");
            Console.WriteLine($"Especial: {Especial}");
            Console.WriteLine($"Limite: {Limite}");
            Console.WriteLine("----------------------");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void EmitirSaldo() => Console.WriteLine($"Saldo atual: R$ {Saldo:F2}");
    }
}