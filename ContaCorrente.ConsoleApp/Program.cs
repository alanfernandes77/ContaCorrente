namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new();
            conta1.Numero = 12;
            conta1.Saldo = 1000;
            conta1.Especial = true;
            conta1.Limite = 0;
            conta1.movimentacoes = new Movimentacao[10];

            ContaCorrente conta2 = new();
            conta2.Numero = 13;
            conta2.Saldo = 500;
            conta2.Especial = false;
            conta2.Limite = 300;
            conta2.movimentacoes = new Movimentacao[10];

            conta1.ExibirConta();
            conta1.Sacar(350);
            conta1.Depositar(300);
            conta1.TransferirPara(conta2, 400);

            conta2.ExibirConta();
            conta2.Sacar(800);
            conta2.Depositar(300);
            conta2.TransferirPara(conta1, 200);

            conta1.ExibirExtrato();
            conta2.ExibirExtrato();
        }
    }
}