import Card from '@mui/material/Card';
import * as React from 'react';

import CardContent from '@mui/material/CardContent';

import Typography from '@mui/material/Typography';

import './passageiroCard.style.css';

import { Button, CardMedia } from '@mui/material';
import { Link } from 'react-router-dom';
import userDefaultImage from '../../../assets/img/avatarDefault.png';

export function PassageiroCard({ id, nome, isDisponivel, onEndRide }) {
  return (
    <Card className="passageiro-card">
      <CardMedia
        sx={{ maxWidth: 140, margin: 'auto', paddingTop: '1em' }}
        component="img"
        height="150"
        image={userDefaultImage}
        alt={`Imagem do ${nome}`}
      />
      <CardContent>
        <Typography textAlign="center" fontWeight="800" variant="h5" component="div">
          {nome}
        </Typography>

        {!isDisponivel ? (
          <Link className="max-width" to={`/ride/${id}`}>
            <Button sx={{ width: '100%', marginTop: '1em' }} variant="outlined" size="large">
              Iniciar Corrida
            </Button>
          </Link>
        ) : (
          <Button
            onClick={() => onEndRide(id)}
            sx={{ width: '100%', marginTop: '1em' }}
            variant="outlined"
            size="large"
          >
            Finalizar Corrida
          </Button>
        )}
      </CardContent>
    </Card>
  );
}
