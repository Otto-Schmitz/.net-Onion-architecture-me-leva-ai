import { axiosInstance } from '../_base/axiosInstance.api';

export async function startRide({ rideId }) {
  const response = await axiosInstance.put(`/corridas/${rideId}/iniciar`);
  return response.data;
}
