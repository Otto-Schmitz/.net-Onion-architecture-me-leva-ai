import { Button, Card, CardMedia, Container, Typography } from '@mui/material';
import { useNavigate, useParams } from 'react-router-dom';
import { requestRide } from '../../../api/user/requestRide.api';
import defaultMapImage from '../../../assets/img/mapDefaultImage.jpg';
import { arrivalCitys, locations, startingCitys } from '../../../constants/index.constants';
import useGlobalUser from '../../../context/user.context';
import { useForm } from '../../../hooks/useForm.hook';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';
import { SelectForm } from '../../components';
import './requestRideScreen.style.css';

const DEFAULT_FORM = { startingCity: '', arrivalCity: '' };

export function RequestRide() {
  const { userId } = useParams();
  const { inputForm, handleFormInputs } = useForm(DEFAULT_FORM);
  const [, , setRide] = useGlobalUser();
  const navigate = useNavigate();

  async function handleClickSubmit(event) {
    event.preventDefault();
    console.log(userId);
    try {
      const response = await requestRide({
        passageiroId: userId,
        PontoInicialX: parseFloat(locations[inputForm.startingCity][0]),
        PontoInicialY: parseFloat(locations[inputForm.startingCity][1]),
        PontoFinalX: parseFloat(locations[inputForm.arrivalCity][0]),
        PontoFinalY: parseFloat(locations[inputForm.arrivalCity][1]),
      });
      setRide({
        user: userId,
        content: response,
      });
      toastMensagem('Corrida solicitada com sucesso.', TOAST_TYPES.success);
      navigate(`/`);
    } catch (error) {
      console.log(error);
      toastMensagem(error.response.data.message, TOAST_TYPES.error);
    }
  }

  return (
    <Container position={'relative'} maxWidth="xl" sx={{ minHeight: '100vh' }}>
      <Typography paddingTop="35px" textAlign={'center'} fontWeight="800" variant="h3">
        Solicitar Corrida
      </Typography>

      <Card
        sx={{ margin: '2em auto', justifyContent: 'center', borderRadius: '10px' }}
        className="card-ride-form "
      >
        <CardMedia
          sx={{ margin: 'auto', borderRadius: '10px' }}
          component="img"
          width="100%"
          image={defaultMapImage}
          alt={`Imagem do mapa`}
        />
        <form onSubmit={handleClickSubmit} className="container-form">
          <SelectForm
            handleChange={handleFormInputs}
            label="Ponto de Partida"
            value={inputForm.startingCity}
            name="startingCity"
            options={startingCitys}
          />
          <SelectForm
            handleChange={handleFormInputs}
            label="Ponto de Chegada"
            value={inputForm.arrivalCity}
            name="arrivalCity"
            options={arrivalCitys}
          />
          <Button variant="outlined" size="large" type="submit">
            Solicitar
          </Button>
        </form>
      </Card>
    </Container>
  );
}
