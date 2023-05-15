import { axiosInstance } from '../_base/axiosInstance.api';

export async function createVehicle({
  placa,
  modelo,
  marca,
  cor,
  categoriaVeiculo,
  foto,
  motoristaId,
  ano,
  quantidadeDeLugares,
}) {
  const response = await axiosInstance.post(
    `v1/veiculos`,
    { motoristaId, placa, marca, modelo, ano, cor, fotoUrl: foto, quantidadeDeLugares, categoriaVeiculo },
    {}
  );
  return response.data;
}
