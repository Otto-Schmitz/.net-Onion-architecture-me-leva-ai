import { axiosInstance } from '../_base/axiosInstance.api';

export async function listar({ page }) {
  const response = await axiosInstance.get('v1/passageiros');

  return response.data;
}
