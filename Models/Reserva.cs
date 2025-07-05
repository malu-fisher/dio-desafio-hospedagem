using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSistemaDeHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
        // *IMPLEMENTE AQUI*
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes != null && hospedes.Count > 0)
            {
                if (Suite.Capacidade >= hospedes.Count)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new ArgumentException("A capacidade da suite é menor que o número de hóspedes solicitados.");
                }
            }
            else
            {
                // Handle the case where there are no guests to add.  Perhaps set Hospedes to an empty list or handle it in a different way.
                Hospedes = new List<Pessoa>(); // Or leave it as is, depending on desired behavior.
            }
        }

         public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }


        // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
        // *IMPLEMENTE AQUI*
        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            else
            {
                return 0; // Or throw an exception if Hospedes is null.
            }
        }

        // TODO: Retorna o valor da diária
        // *IMPLEMENTE AQUI*
        public decimal CalcularValorDiaria()
        {
            if (DiasReservados >= 10)
            {
                decimal desconto = 0.10m; // 10% discount
                decimal valor = DiasReservados * Suite.ValorDiaria * (1 - desconto);
                return valor;
            }
            else
            {
                return DiasReservados * Suite.ValorDiaria;
            }
        }
    }

}
