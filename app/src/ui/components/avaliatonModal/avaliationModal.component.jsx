import * as React from 'react';
import Backdrop from '@mui/material/Backdrop';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Fade from '@mui/material/Fade';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { Rating, Stack } from '@mui/material';
import useGlobalUser from '../../../context/user.context';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';
import { ratingPassanger as ratingPassangerApi } from '../../../api/rating/ratingPassanger.api';
import { ratingDriver as ratingDriverApi } from '../../../api/rating/ratingDriver.api';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

export function AvaliationModal({ id, open, handleModalClose }) {
  const [ratingPassanger, setRatingPassanger] = React.useState(0);
  const [ratingDriver, setRatingDriver] = React.useState(0);

  const [, , , getRide] = useGlobalUser();

  function handleRatingPassenger(e, rating) {
    setRatingPassanger(rating);
  }

  function handleRatingDriver(e, rating) {
    setRatingDriver(rating);
  }

  async function handleClickRating() {
    try {
      ratingPassanger && (await ratingPassangerApi({ passangerId: id, rating: ratingPassanger }));
      ratingDriver && (await ratingDriverApi({ driverId: getRide(id).motorista.id, rating: ratingDriver }));
      toastMensagem('Avaliação feita com sucesso.', TOAST_TYPES.success);
      handleModalClose();
    } catch (error) {
      toastMensagem('Algo deu errado.', TOAST_TYPES.error);
    }
  }

  return (
    <div>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        open={open}
        onClose={handleModalClose}
        closeAfterTransition
        slots={{ backdrop: Backdrop }}
        slotProps={{
          backdrop: {
            timeout: 500,
          },
        }}
      >
        <Fade in={open}>
          <Box sx={style} padding="0 60px">
            <Typography
              textAlign="center"
              marginBottom="2em"
              id="transition-modal-title"
              variant="h6"
              component="h2"
            >
              Avaliar
            </Typography>
            <Stack spacing={3}>
              <Stack flexDirection="row" justifyContent="space-between" alignItems="center">
                <Typography>Passageiro:</Typography>
                <Rating onChange={handleRatingPassenger} name="size-large" defaultValue={0} size="large" />
              </Stack>
              <Stack flexDirection="row" justifyContent="space-between" alignItems="center">
                <Typography>Motorista:</Typography>
                <Rating onChange={handleRatingDriver} name="size-large" defaultValue={0} size="large" />
              </Stack>
            </Stack>
            <Button
              onClick={handleClickRating}
              sx={{ width: '100%', marginTop: '2em' }}
              variant="outlined"
              size="large"
            >
              Enviar
            </Button>
          </Box>
        </Fade>
      </Modal>
    </div>
  );
}
