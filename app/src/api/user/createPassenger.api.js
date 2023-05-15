import { axiosInstance } from '../_base/axiosInstance.api';

export async function createPassenger({ nome, dataNascimento, cpf, email }) {
  const response = await axiosInstance.post(`v1/passageiros`, { nome, dataNascimento, cpf, email }, {});
  return response.data;
}
