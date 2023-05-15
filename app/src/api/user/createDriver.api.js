import { axiosInstance } from '../_base/axiosInstance.api';

export async function createDriver({ nome, email, dataNascimento, cpf, numero, categoria, dataVencimento }) {
  const response = await axiosInstance.post(
    `/v1/motoristas`,
    { nome, email, dataNascimento, cpf, numero, categoria, dataVencimento },
    {}
  );
  return response.data;
}
