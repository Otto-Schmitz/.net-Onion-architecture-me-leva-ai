import { Container, Typography } from '@mui/material';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { startRide } from '../../../api/ride/startRide.api';
import useGlobalUser from '../../../context/user.context';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';
import { Loading, MotoristaCard } from '../../components';

export function CurrentRideScreen() {
  const { userId } = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [, , , getRide] = useGlobalUser();
  const navigate = useNavigate();

  useEffect(() => {
    function setLoading() {
      if (getRide() !== null) {
        setIsLoading(false);
      }
    }

    setLoading();
  }, [getRide]);

  async function handleSubmit() {
    try {
      const response = await startRide({ rideId: getRide(userId).id });
      toastMensagem(
        <div>
          Corrida iniciada. <br />
          Valor estimado: R$ {response.valorEstimado} <br />
          Tempo estimado: {(response.tempoEstimado / 60).toFixed(0)} minutos
        </div>,
        TOAST_TYPES.success
      );
      navigate('/');
    } catch (error) {
      toastMensagem('Algo deu errado.', TOAST_TYPES.error);
    }
  }

  function renderCurrentRide() {
    if (isLoading) return <Loading />;

    const ride = getRide(userId);
    if (!ride) {
      toastMensagem('Corrida não encontrada.', TOAST_TYPES.error);
      return <Loading />;
    }

    return cardContent(ride);
  }

  function cardContent({ motorista, veiculo, tempoEstimado }) {
    return (
      <MotoristaCard
        name={motorista.nome}
        carPhoto={veiculo.foto}
        rating={motorista.avaliacao}
        estimatedTime={tempoEstimado}
        car={veiculo.modelo}
        licensePlate={veiculo.placa}
        handleSubmit={handleSubmit}
      />
    );
  }

  return (
    <Container position={'relative'} maxWidth="xl" sx={{ minHeight: '100vh' }}>
      <Typography paddingTop="35px" textAlign={'center'} fontWeight="800" variant="h3">
        Corrida Atual
      </Typography>
      {renderCurrentRide()}
    </Container>
  );
}
