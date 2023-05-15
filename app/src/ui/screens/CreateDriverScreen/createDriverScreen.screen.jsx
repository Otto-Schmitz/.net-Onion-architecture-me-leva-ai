import { Button, Card, CardMedia, InputAdornment, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import { useNavigate } from 'react-router-dom';
import { createDriver } from '../../../api/user/createDriver.api';
import { createVehicle } from '../../../api/user/createVehicle.api';
import userDefaultImage from '../../../assets/img/avatarDefault.png';
import { licenseType } from '../../../constants/index.constants';
import { useForm } from '../../../hooks/useForm.hook';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';
import { SelectForm } from '../../components';

const DEFAULT_FORM = {
  nome: '',
  email: '',
  dataNascimento: '',
  cpf: '',

  numero: '',
  categoria: '',
  dataVencimento: '',

  placa: '',
  marca: '',
  modelo: '',
  ano: '',
  cor: '',
  foto: '',
  quantidadeDeLugares: '',
  categoriaVeiculo: '',
};

export function CreateDriverScreen() {
  const { inputForm, handleFormInputs } = useForm(DEFAULT_FORM);
  const navigate = useNavigate();

  async function handleClickSubmit() {
    console.log(inputForm, 'chegou');
    try {
      const driverId = await createDriver({
        ...inputForm,
      });
      await createVehicle({ ...inputForm, motoristaId: driverId.id });
      console.log('qq');
      toastMensagem('Motorista criado com sucesso.', TOAST_TYPES.success);
      navigate('/');
    } catch (error) {
      console.log(error);
      toastMensagem(error.response.data.message, TOAST_TYPES.error);
    }
  }

  function formValidator(event) {
    event.preventDefault();
    console.log(inputForm);
    const validate = [
      cpfValidator(),
      numeroCarteiraValidator(),
      categoriaValidator(),
      placaValidator(),
    ].every((value) => value);

    if (validate) {
      handleClickSubmit();
    }
  }

  function categoriaCarteiraValidator() {
    if (inputForm.categoria === 'A') inputForm.categoria = 0;
    else if (inputForm.categoria === 'B') inputForm.categoria = 1;
    else inputForm.categoria = 2;

    console.log(inputForm.categoria);
  }

  function categoriaVeiculoValidator() {
    if (inputForm.categoriaVeiculo === 'A') inputForm.categoriaVeiculo = 0;
    else if (inputForm.categoriaVeiculo === 'B') inputForm.categoriaVeiculo = 1;
    else inputForm.categoriaVeiculo = 2;

    console.log(inputForm.categoriaVeiculo);
  }

  function cpfValidator() {
    const limitChar = 11;
    if (inputForm.cpf.length !== limitChar) {
      toastMensagem('Cpf deve ser válido.', TOAST_TYPES.warning);
      return false;
    }
    if (parseInt(inputForm.cpf) < 0) {
      toastMensagem('Cpf deve ser válido', TOAST_TYPES.warning);
      return false;
    }
    return true;
  }

  function numeroCarteiraValidator() {
    const limitChar = 11;
    if (inputForm.numero.length !== limitChar) {
      toastMensagem(`Número da Carteira deve conter ${limitChar} caracteres.`, TOAST_TYPES.warning);
      return false;
    }
    if (parseInt(inputForm.numeroCarteira) < 0) {
      toastMensagem('Número da Carteira deve ser válido.', TOAST_TYPES.warning);
    }
    return true;
  }

  function placaValidator() {
    const limitChar = 7;
    if (inputForm.placa.length !== limitChar) {
      toastMensagem('Placa deve ter 7 caracteres.', TOAST_TYPES.warning);
      return false;
    }
    return true;
  }

  function categoriaValidator() {
    if (inputForm.categoria !== inputForm.categoriaVeiculo) {
      toastMensagem('Motorista deve ter a mesma categoria do veiculo.', TOAST_TYPES.warning);
      return false;
    }
    return true;
  }

  return (
    <Container position={'relative'} maxWidth="xl" sx={{ minHeight: '100vh' }}>
      <Typography paddingTop="35px" textAlign={'center'} fontWeight="800" variant="h3">
        Cadastrar Motorista
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
            onChange={handleFormInputs}
            inputProps={{ maxLength: 50 }}
            value={inputForm.nome}
            required
          />
          <TextField
            id="outlined-basic"
            label="Email"
            variant="outlined"
            type={'text'}
            name="email"
            onChange={handleFormInputs}
            value={inputForm.email}
            required
          />
          <TextField
            id="outlined-basic"
            label="Data Nascimento"
            InputProps={{
              startAdornment: <InputAdornment position="end"></InputAdornment>,
            }}
            type={'date'}
            name="dataNascimento"
            onChange={handleFormInputs}
            value={inputForm.dataNascimento}
            required
          />
          <TextField
            id="outlined-basic"
            label="Cpf"
            variant="outlined"
            type={'number'}
            name="cpf"
            onChange={handleFormInputs}
            value={inputForm.cpf}
            required
          />
          <TextField
            id="outlined-basic"
            label="Numero da Carteira"
            variant="outlined"
            type={'number'}
            name="numero"
            onChange={handleFormInputs}
            value={inputForm.numero}
            required
          />
          <SelectForm
            handleChange={handleFormInputs}
            label="Categoria da Carteira"
            value={inputForm.categoria}
            name="categoria"
            options={licenseType}
            required
          />
          <TextField
            id="outlined-basic"
            label="Data de Vencimento da Carteira"
            InputProps={{
              startAdornment: <InputAdornment position="end"></InputAdornment>,
            }}
            type={'date'}
            name="dataVencimento"
            onChange={handleFormInputs}
            value={inputForm.dataVencimento}
            required
          />

          <Typography textAlign={'center'} fontWeight="800" variant="h4">
            Veiculo
          </Typography>

          <TextField
            id="outlined-basic"
            label="Placa"
            variant="outlined"
            type={'text'}
            name="placa"
            onChange={handleFormInputs}
            inputProps={{ maxLength: 7 }}
            value={inputForm.placa}
            required
          />
          <TextField
            id="outlined-basic"
            label="Marca"
            type={'text'}
            name="marca"
            onChange={handleFormInputs}
            value={inputForm.marca}
            required
          />
          <TextField
            id="outlined-basic"
            label="Modelo"
            type={'text'}
            name="modelo"
            onChange={handleFormInputs}
            value={inputForm.modelo}
            required
          />
          <TextField
            id="outlined-basic"
            label="Ano"
            type={'text'}
            name="ano"
            onChange={handleFormInputs}
            value={inputForm.ano}
            required
          />
          <TextField
            id="outlined-basic"
            label="Cor"
            variant="outlined"
            type={'text'}
            name="cor"
            onChange={handleFormInputs}
            value={inputForm.cor}
            required
          />
          <TextField
            id="outlined-basic"
            label="Quantidade de Lugares"
            type={'number'}
            name="quantidadeDeLugares"
            onChange={handleFormInputs}
            value={inputForm.quantidadeDeLugares}
            required
          />

          <SelectForm
            handleChange={handleFormInputs}
            label="Categoria do Veiculo"
            value={inputForm.categoriaVeiculo}
            name="categoriaVeiculo"
            options={licenseType}
            required
          />
          <TextField
            id="outlined-basic"
            label="URL Foto"
            type={'text'}
            name="foto"
            onChange={handleFormInputs}
            value={inputForm.foto}
            required
          />
          {inputForm.foto && (
            <CardMedia
              sx={{ margin: 'auto', borderRadius: '10px', width: '50%' }}
              component="img"
              image={inputForm.foto}
            />
          )}

          <Button variant="outlined" size="large" type="submit">
            Cadastrar
          </Button>
        </form>
      </Card>
    </Container>
  );
}
