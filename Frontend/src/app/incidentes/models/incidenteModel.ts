export class IncidenteModel {
    ocorrenciaId: string;
    tipoOcorrenciaId: string;
    insumoId: string;
    emissorId: string;
    setorId: string;
    statusId: string;
    titulo: string;
    dataHora: string;
    descricao: string;
    consequencias: string;
    prioridade: number;
    ativo: boolean;
    divulgadoInternamente: boolean;
    divulgadoExternamente: boolean;
}