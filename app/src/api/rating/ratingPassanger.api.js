import { axiosInstance } from '../_base/axiosInstance.api';

export async function ratingPassanger({ passangerId, rating }) {
  const response = await axiosInstance.put(`/passageiros/${passangerId}/avaliar`, { nota: rating });
  return response.data;
}
