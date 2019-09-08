using CIP.API.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Infrastructure
{
    public class CIPContextSeed
    {
        public async Task SeedAsync(CIPContext context)
        {

            if (!context.Status.Any())
            {
                var status1 = new Status()
                {
                    StatusId = Guid.Parse("5E19A1CF-8F89-4082-94FA-0ACB270F455A"),
                    Descricao = "A incidencia ainda encontra-se em execução",
                    Nome = "Em execução"
                };

                var status2 = new Status()
                {
                    StatusId = Guid.Parse("84C309D1-7432-4B3A-BD57-6AEB0CDE36B7"),
                    Descricao = "A incidencia foi resolvida",
                    Nome = "Resolvido"
                };

                var status3 = new Status()
                {
                    StatusId = Guid.Parse("2A364A73-38A0-4EA1-A18B-823A0A9D459A"),
                    Descricao = "Em fila a ser executado",
                    Nome = "Em fila"
                };

                await context.Status.AddAsync(status1);
                await context.Status.AddAsync(status2);
                await context.Status.AddAsync(status3);
                await context.SaveChangesAsync();
            }

            if (!context.Setor.Any())
            {
                var setor1 = new Setor()
                {
                    SetorId = Guid.Parse("2F17FA29-47DC-4191-B1C0-FD8BE8265966"),
                    Descricao = "Setor voltado a parte mecanica",
                    Nome = "Engenharia mecanica"
                };

                var setor2 = new Setor()
                {
                    SetorId = Guid.Parse("218783B7-A9BF-402E-9ACD-E55E55875127"),
                    Descricao = "Setor voltado a parte eletrica",
                    Nome = "Engenharia eletrica"
                };

                var setor3 = new Setor()
                {
                    SetorId = Guid.Parse("7F6B0FE3-B1D0-445C-AE18-113F15641D47"),
                    Descricao = "Setor voltado a montagem",
                    Nome = "Montagem"
                };

                await context.Setor.AddAsync(setor1);
                await context.Setor.AddAsync(setor2);
                await context.Setor.AddAsync(setor3);
                await context.SaveChangesAsync();
            }

            if (!context.Insumo.Any())
            {
                var insumo1 = new Insumo()
                {
                    InsumoId = Guid.Parse("2A25B3E7-0911-43BB-AC1E-38A01C6B7132"),
                    Descricao = "Veiculo em desenvolvimento, cujo ainda não está na linha de montagem",
                    Tipo = "Veiculo em desenvolvimento"
                };

                var insumo2 = new Insumo()
                {
                    InsumoId = Guid.Parse("B5FB7B03-0254-449D-8505-E5763912A57D"),
                    Descricao = "Veiculo em produção, que está na linha de montagem",
                    Tipo = "Veiculo em produção"
                };

                var insumo3 = new Insumo()
                {
                    InsumoId = Guid.Parse("BA8595A9-F4DB-4515-9C84-3FA0FC38112C"),
                    Descricao = "Veiculo em venda, que está em venda",
                    Tipo = "Veiculo em venda"
                };

                await context.Insumo.AddAsync(insumo1);
                await context.Insumo.AddAsync(insumo2);
                await context.Insumo.AddAsync(insumo3);
                await context.SaveChangesAsync();
            }

            if (!context.Emissor.Any())
            {
                var emissor1 = new Emissor()
                {
                    EmissorId = Guid.Parse("48F824C8-8F56-43BA-A33F-1DDB87E074A2"),
                    Nome = "Luiz",
                    Email = "luiz@sgq.com",
                    Senha = "123456",
                    PermissaoCadastro = true,
                    PermissaoVisualizacao = true
                };

                var emissor2 = new Emissor()
                {
                    EmissorId = Guid.Parse("B41B9FF9-5C8F-4FB4-9A00-A3EECA99D4A6"),
                    Nome = "Vitor",
                    Email = "vitor@sgq.com",
                    Senha = "123456",
                    PermissaoCadastro = false,
                    PermissaoVisualizacao = true
                };

                await context.Emissor.AddAsync(emissor1);
                await context.Emissor.AddAsync(emissor2);
                await context.SaveChangesAsync();
            }

            if (!context.TipoOcorrencia.Any())
            {
                var tipoOcorrencia1 = new TipoOcorrencia()
                {
                    TipoOcorrenciaId = Guid.Parse("5A351983-DBEE-4891-9801-A42AA752B49B"),
                    Tipo = "Preventiva",
                    Descricao = "Ações a serem tomadas como monitoramento e melhoria."
                };

                var tipoOcorrencia2 = new TipoOcorrencia()
                {
                    TipoOcorrenciaId = Guid.Parse("2DC1BAA5-1337-4629-AEFD-22290E3BB243"),
                    Tipo = "Corretiva",
                    Descricao = "Ações a serem tomadas para corrigir problemas existentes"
                };

                var tipoOcorrencia3 = new TipoOcorrencia()
                {
                    TipoOcorrenciaId = Guid.Parse("960819BA-B874-4397-A407-CAD187D77892"),
                    Tipo = "Recall",
                    Descricao = "Ação de subistituição de peças já introduzidas no mercado"
                };

                await context.TipoOcorrencia.AddAsync(tipoOcorrencia1);
                await context.TipoOcorrencia.AddAsync(tipoOcorrencia2);
                await context.TipoOcorrencia.AddAsync(tipoOcorrencia3);
                await context.SaveChangesAsync();
            }

            if (!context.Ocorrencia.Any())
            {
                var ocorrencia1 = new Ocorrencia()
                {
                    OcorrenciaId = Guid.Parse("FDF3083D-F878-4294-BE0D-493C5C9B5BDF"),
                    Titulo = "Risco de quebra do Motor do veiculo X",
                    DataHora = DateTime.Now,
                    Descricao = "Motor do veiculo X apresentando superaquecimento nos teste de pista.",
                    Consequencias = "Risco de quebra acima de 90 graus.",
                    Prioridade = 10,
                    Ativo = true,
                    TipoOcorrenciaId = Guid.Parse("5A351983-DBEE-4891-9801-A42AA752B49B"),
                    EmissorId = Guid.Parse("48F824C8-8F56-43BA-A33F-1DDB87E074A2"),
                    InsumoId = Guid.Parse("2A25B3E7-0911-43BB-AC1E-38A01C6B7132"),
                    SetorId = Guid.Parse("2F17FA29-47DC-4191-B1C0-FD8BE8265966"),
                    StatusId = Guid.Parse("5E19A1CF-8F89-4082-94FA-0ACB270F455A"),
                    DivulgadoExternamente = false,
                    DivulgadoInternamente = true
                };

                var ocorrencia2 = new Ocorrencia()
                {
                    OcorrenciaId = Guid.Parse("A02C6845-4D0D-4393-A4FF-39A56ECBE536"),
                    Titulo = "Risco airbag acionar sozinho no veiculo Y.",
                    DataHora = DateTime.Now,
                    Descricao = "Veiculo Y apresentando o acionamento do airbag em ocasições não esperadas.",
                    Consequencias = "Risco de acicentes de transito por conta de acionamento não esperado do airbag.",
                    Prioridade = 50,
                    Ativo = true,
                    TipoOcorrenciaId = Guid.Parse("960819BA-B874-4397-A407-CAD187D77892"),
                    EmissorId = Guid.Parse("48F824C8-8F56-43BA-A33F-1DDB87E074A2"),
                    InsumoId = Guid.Parse("BA8595A9-F4DB-4515-9C84-3FA0FC38112C"),
                    SetorId = Guid.Parse("218783B7-A9BF-402E-9ACD-E55E55875127"),
                    StatusId = Guid.Parse("84C309D1-7432-4B3A-BD57-6AEB0CDE36B7"),
                    DivulgadoExternamente = true,
                    DivulgadoInternamente = true
                };

                await context.Ocorrencia.AddAsync(ocorrencia1);
                await context.Ocorrencia.AddAsync(ocorrencia2);
                await context.SaveChangesAsync();
            }

            if (!context.Cronograma.Any())
            {
                var cronograma1 = new Cronograma()
                {
                    CronogramaId = Guid.Parse("62CE23BD-0DC1-4E2C-A743-EDA4691AED07"),
                    OcorrenciaId = Guid.Parse("FDF3083D-F878-4294-BE0D-493C5C9B5BDF"),
                    DataHoraAcao = DateTime.Now.AddDays(1),
                    Etapa = 1,
                    Norma = "ABNT NBR ISO 6626:2011",
                    PlanoDeAcao = "Fazer teste com outros tipos de óleo de motores. O mesmo deve suportar a temperatura de 140 graus.",
                    Executado = false,
                    Resultado = ""

                };

                var cronograma2 = new Cronograma()
                {
                    CronogramaId = Guid.Parse("B7A2836E-8646-4AE6-BE2A-1EED3CCDD0B0"),
                    OcorrenciaId = Guid.Parse("A02C6845-4D0D-4393-A4FF-39A56ECBE536"),
                    DataHoraAcao = DateTime.Now,
                    Etapa = 1,
                    Norma = "NBR 13776",
                    PlanoDeAcao = "Identificar motivo do acionamento não esperado do airbag.",
                    Executado = true,
                    Resultado = "Será feito a troca do AirBag nas concessionarioas autorizadas."

                };

                await context.Cronograma.AddAsync(cronograma1);
                await context.Cronograma.AddAsync(cronograma2);
                await context.SaveChangesAsync();
            }
        }


    }
}
