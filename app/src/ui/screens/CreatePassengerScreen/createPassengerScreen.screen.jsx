import { Button, Card, CardMedia, InputAdornment, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createPassenger } from '../../../api/user/createPassenger.api';
import userDefaultImage from '../../../assets/img/avatarDefault.png';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';

export function CreatePassengerScreen() {
  const [information, setInformation] = useState({});
  const navigate = useNavigate();

  async function handleClickSubmit() {
    try {
      await createPassenger(information);
      toastMensagem('Passageiro criado com sucesso.', TOAST_TYPES.success);
      navigate('/');
    } catch (error) {
      toastMensagem(error.response.data.message, TOAST_TYPES.error);
    }
  }

  function formValidator(event) {
    event.preventDefault();
    if (cpfValidator()) {
      handleClickSubmit();
    }
  }

  function cpfValidator() {
    const limitChar = 11;
    if (information['cpf'].length !== limitChar) {
      toastMensagem(`Cpf deve conter ${limitChar} caracteres`, TOAST_TYPES.warning);
      return false;
    }
    if (parseInt(information['cpf']) < 0) {
      toastMensagem('Cpf deve ser válido', TOAST_TYPES.warning);
      return false;
    }
    return true;
  }

  function handleChange(event) {
    const { name, value } = event.target;
    setInformation((olderInformation) => ({
      ...olderInformation,
      [name]: value,
    }));
  }

  return (
    <Container position={'relative'} maxWidth="xl" sx={{ minHeight: '100vh' }}>
      <Typography paddingTop="35px" textAlign={'center'} fontWeight="800" variant="h3">
        Cadastrar Passageiro
      </Typography>

      <Card
        sx={{ margin: '2em auto', justifyContent: 'center', borderRadius: '10px' }}
        className="card-ride-form "
      >
        <CardMedia
          sx={{ margin: 'auto', borderRadius: '10px', width: '50%' }}
          component="img"
          image={userDefaultImage}
          alt={`Imagem do mapa`}
        />
        <form onSubmit={formValidator} className="container-form">
          <TextField
            id="outlined-basic"
            label="Nome"
            variant="outlined"
            type={'text'}
            name="nome"
            onChange={handleChange}
            inputProps={{ maxLength: 50 }}
          />
          <TextField
            id="outlined-basic"
            label="Data Nascimento"
            InputProps={{
              startAdornment: <InputAdornment position="end"></InputAdornment>,
            }}
            type={'date'}
            name="dataNascimento"
            onChange={handleChange}
          />
          <TextField
            id="outlined-basic"
            label="Cpf"
            variant="outlined"
            type={'number'}
            name="cpf"
            onChange={handleChange}
            inputProps={{ maxLength: 11 }}
          />
          <TextField
            id="outlined-basic"
            label="Email"
            variant="outlined"
            type={'email'}
            name="email"
            onChange={handleChange}
          />
          <Button variant="outlined" size="large" type="submit">
            Cadastrar
          </Button>
        </form>
      </Card>
    </Container>
  );
}
