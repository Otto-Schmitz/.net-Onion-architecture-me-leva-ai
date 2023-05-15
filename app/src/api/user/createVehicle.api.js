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
  console.log(foto);
  const response = await axiosInstance.post(
    `v1/veiculos`,
    { motoristaId, placa, marca, modelo, ano, cor, foto, quantidadeDeLugares, categoriaVeiculo },
    {}
  );
  return response.data;
}
