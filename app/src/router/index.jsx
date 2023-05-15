import { createBrowserRouter } from 'react-router-dom';

import {
  CreateDriverScreen,
  CreatePassengerScreen,
  CurrentRideScreen,
  Home,
  RequestRide,
} from '../ui/screens';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
  },
  {
    path: '/ride/:userId',
    element: <RequestRide />,
  },
  {
    path: '/ride/:userId/current',
    element: <CurrentRideScreen />,
  },
  {
    path: '/passenger/create',
    element: <CreatePassengerScreen />,
  },
  {
    path: '/driver/create',
    element: <CreateDriverScreen />,
  },
]);
