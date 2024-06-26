import { axiosInstance } from '../_base/axiosInstance.api';

export async function requestRide({
  passageiroId,
  PontoInicialX,
  PontoInicialY,
  PontoFinalX,
  PontoFinalY = 10,
}) {
  const response = await axiosInstance.post(
    'v1/corridas/chamar',
    { passageiroId, PontoInicialX, PontoInicialY, PontoFinalX, PontoFinalY },
    {}
  );
  return response.data;
}
