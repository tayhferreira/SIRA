using System;

namespace SIRA.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("=== SIRA: SISTEMA INTELIGENTE DE REDISTRIBUIÇÃO DE ALIMENTOS ===");

                // 1. Instanciando atores reais do ecossistema local
                // Substituímos o genérico por nomes que trazem mais peso ao cenário de negócio
                var redeVarejo = new Estabelecimento(
                    1, 
                    "Hortifruti Da Terra", 
                    "logistica@daterra.com.br", 
                    "Auth#9921", 
                    "44.555.666/0001-22", 
                    "Av. Rio Branco, 450 - Franca/SP"
                );

                var bancoAlimentos = new Instituicao(
                    2, 
                    "Centro de Apoio Esperança", 
                    "contato@esperanca.org", 
                    "SafePass@2026", 
                    "Social-SP-12345"
                );

                // 2. Cadastro de Alimento com dados específicos
                var loteTomates = new Alimento(
                    101, 
                    "Tomate Italiano (Caixa 10kg)", 
                    DateTime.Now.AddDays(4), 
                    15.5
                );
                
                redeVarejo.PostarAlimento(loteTomates);

                // 3. Simulação do fluxo de reserva e transação
                bancoAlimentos.SolicitarReserva(loteTomates);
                
                var transacaoAtiva = new Transacao(7001, loteTomates);
                Console.WriteLine("\n--- Detalhes da Operação ---");
                Console.WriteLine(transacaoAtiva.GerarRecibo());

                // 4. Finalização do ciclo de vida do objeto
                transacaoAtiva.ConfirmarRetirada();
                
                Console.WriteLine("\n[STATUS]: Fluxo de redistribuição concluído com sucesso.");
            }
            catch (ArgumentException ex)
            {
                // Tratamento específico para as validações que criamos nos construtores
                Console.WriteLine($"[ERRO DE VALIDAÇÃO]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO CRÍTICO]: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar o console...");
            Console.ReadKey();
        }
    }
}