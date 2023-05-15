import { axiosInstance } from '../_base/axiosInstance.api';

export async function ratingDriver({ driverId, rating }) {
  const response = await axiosInstance.put(`/motoristas/${driverId}/avaliar`, { nota: rating });
  return response.data;
}
