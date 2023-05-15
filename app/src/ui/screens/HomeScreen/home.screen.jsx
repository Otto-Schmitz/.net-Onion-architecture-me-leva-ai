import { Grid, Typography } from '@mui/material';
import { Container } from '@mui/system';
import React, { useEffect, useState } from 'react';
import { toastMensagem, TOAST_TYPES } from '../../../toast/toast';

import { endRide } from '../../../api/ride/endRide.api';
import { listar } from '../../../api/user/listar.api';
import useGlobalUser from '../../../context/user.context';
import { AvaliationModal, BasicMenu, Loading, PassageiroCard } from '../../components';

export function Home() {
  const [passageiros, setPassageiros] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [page, setPage] = useState(1);
  const [, , , getRide] = useGlobalUser();
  const [curentPassangerId, setCurentPassangerId] = useState(null);
  const [showModal, setShowModal] = React.useState(false);

  useEffect(() => {
    async function getListagem() {
      try {
        setIsLoading(true);
        const responseListagem = await listar({ page: page - 1 });
        setPassageiros(responseListagem);
      } catch (error) {
        toastMensagem('Algo deu errado.', TOAST_TYPES.error);
      } finally {
        setIsLoading(false);
      }
    }

    getListagem();
  }, [page]);

  useEffect(() => {
    async function refreshList() {
      if (!showModal) {
        try {
          const responseListagem = await listar({ page: page - 1 });
          setPassageiros(responseListagem);
        } catch (error) {
          toastMensagem('Algo deu errado.', TOAST_TYPES.error);
        }
      }
    }
    refreshList();
  }, [showModal, page]);

  async function handleEndRide(idPassageiro) {
    setCurentPassangerId(idPassageiro);

    const rideId = getRide(idPassageiro).id;
    try {
      await endRide({ rideId });
      setShowModal(true);
    } catch (error) {
      toastMensagem(error.response.data.message, TOAST_TYPES.error);
    }
  }

  function renderHome() {
    if (isLoading) return <Loading />;
    return (
      <>
        <Grid marginTop={'20px'} justifyContent={'center'} spacing={4} container>
          {passageiros?.map(({ id, nome, emCorrida }) => (
            <Grid item xs={12} sm={6} md={6} lg={3} xl={3} key={id}>
              <PassageiroCard nome={nome} id={id} isDisponivel={emCorrida} onEndRide={handleEndRide} />
            </Grid>
          ))}
        </Grid>
      </>
    );
  }

  return (
    <Container position={'relative'} maxWidth="xl">
      <BasicMenu />
      <Typography paddingTop="35px" textAlign={'center'} fontWeight="800" variant="h3">
        Passageiros
      </Typography>
      {renderHome()}
      <AvaliationModal id={curentPassangerId} open={showModal} handleModalClose={() => setShowModal(false)} />
    </Container>
  );
}
