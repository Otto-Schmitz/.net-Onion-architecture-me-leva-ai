import { axiosInstance } from '../_base/axiosInstance.api';

export async function endRide({ rideId }) {
  const response = await axiosInstance.put(`/corridas/${rideId}/finalizar`);
  return response.data;
}
