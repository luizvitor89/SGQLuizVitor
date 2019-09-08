using DT.API.Entities;
using DT.API.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.Infrastructure
{
    public class DTContextSeed
    {
        private static DTContext ctx;
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory)
        {
            var config = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<DTSettings>>();

            ctx = new DTContext(config);
            if (!ctx.Divulgacao.Database.GetCollection<Divulgacao>(nameof(Divulgacao)).AsQueryable().Any())
            {
                var divulgacao1 = new Divulgacao()
                {
                    Id = Guid.Parse("7D9D542F-9916-483B-9DEF-69433E859CC2"),
                    OcorrenciaId = Guid.Parse("FDF3083D-F878-4294-BE0D-493C5C9B5BDF"),
                    EmissorId = Guid.Parse("48F824C8-8F56-43BA-A33F-1DDB87E074A2"),
                    Titulo = "Risco de quebra do Motor do veiculo X",
                    Descricao = "Motor do veiculo X apresentando superaquecimento nos teste de pista.",
                    Resumo = "Há vários tipos de motor, e entre eles se destaca, pela importância, o motor de combustão interna. Um motor de combustão interna funciona em quatro tempos: aspiração, compressão, combustão (potência) e exaustão. ... Combustão significa “queima”, e o combustível utilizado geralmente nos motores desse tipo é a gasolina.",
                    Consequencias = "Risco de quebra acima de 90 graus.",
                    CorpoDivulgacao = "O motor que normalmente equipa os automóveis movidos a gasolina é o motor de combustão interna, também chamado de motor de explosão interna ou motor a explosão de quatro tempos. Os termos combustão e explosão são usados no nome desse motor porque o seu princípio de funcionamento baseia - se no aproveitamento da energia liberada na reação de combustão de uma mistura de ar e combustível que ocorre dentro do cilindro do veículo.Esse motor também é chamado de motor de quatro tempos porque seu funcionamento ocorre em quatro estágios ou tempos diferentes.",
                    DataHora = DateTime.Now,
                    DivulgadoExternamente = false,
                    DivulgadoInternamente = true
                };

                var divulgacao2 = new Divulgacao()
                {
                    Id = Guid.Parse("68210A43-5456-464C-9521-5F140A4C9A86"),
                    OcorrenciaId = Guid.Parse("A02C6845-4D0D-4393-A4FF-39A56ECBE536"),
                    EmissorId = Guid.Parse("48F824C8-8F56-43BA-A33F-1DDB87E074A2"),
                    Titulo = "Risco airbag acionar sozinho no veiculo Y.",
                    Descricao = "Veiculo Y apresentando o acionamento do airbag em ocasições não esperadas.",
                    Resumo = "É importante ressaltar que o Airbag foi desenvolvido para ser acionado apenas no caso de impactos fortes envolvendo o veículo. No caso de batidas mais leves, o cinto de segurança é capaz de conter a projeção dos ocupantes do carro e evitar que eles sofram ferimentos sérios.",
                    Consequencias = "Risco de acicentes de transito por conta de acionamento não esperado do airbag.",
                    CorpoDivulgacao = "Para entender como funciona o airbag é preciso conhecer o momento da sua ativação. É no momento em que um motorista freia bruscamente que o equipamento é ativado. Isso ocorre rapidamente porque, como o carro apresenta sensores de velocidade, um sinal é enviado para o ignitor do gerador de gás.",
                    DataHora = DateTime.Now,
                    DivulgadoExternamente = true,
                    DivulgadoInternamente = true
                };

                await ctx.Divulgacao.InsertOneAsync(divulgacao1);
                await ctx.Divulgacao.InsertOneAsync(divulgacao2);
            }
        }

    }
}
