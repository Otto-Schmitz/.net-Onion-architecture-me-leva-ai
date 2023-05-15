import AccessTimeIcon from '@mui/icons-material/AccessTime';
import StarRateRoundedIcon from '@mui/icons-material/StarRateRounded';
import { Button, Card, CardMedia, Typography } from '@mui/material';
import { Box } from '@mui/system';

export function MotoristaCard({ name, carPhoto, car, licensePlate, rating, estimatedTime, handleSubmit }) {
  return (
    <Card
      sx={{ margin: '2em auto', justifyContent: 'center', borderRadius: '10px' }}
      className="card-ride-form "
    >
      <CardMedia
        sx={{ margin: 'auto', borderRadius: '10px' }}
        component="img"
        width="100%"
        image={carPhoto}
        alt={`Imagem do carro`}
      />

      <Box margin={'auto'}>
        <Typography variant="h5" textAlign="center" fontWeight={'800'}>
          {name}
        </Typography>
        <Typography variant="h5" textAlign="center" fontWeight={'800'}>
          {car}
        </Typography>
        <Typography textAlign={'center'} fontWeight={'0'}>
          {licensePlate}
        </Typography>
      </Box>

      <Box marginTop={'1em'} component="div" display={'flex'} gap="1em" justifyContent={'center'}>
        <Box display={'flex'}>
          <StarRateRoundedIcon />
          <Typography textAlign="center" fontWeight="800" variant="p">
            {rating}
          </Typography>
        </Box>

        <Box display={'flex'}>
          <AccessTimeIcon />
          <Typography textAlign="center" fontWeight="800" variant="p">
            {`${estimatedTime} minutos`}
          </Typography>
        </Box>
      </Box>
      <Button variant="outlined" size="large" type="submit" onClick={handleSubmit}>
        Iniciar Corrida
      </Button>
    </Card>
  );
}
