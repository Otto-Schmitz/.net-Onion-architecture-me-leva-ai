import { RouterProvider } from 'react-router-dom';
import { GlobalUserProvider } from './context/user.context';
import { router } from './router';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';

const darkTheme = createTheme({
	palette: {
		mode: 'dark',
	},
});

function App() {
	return (
		<ThemeProvider theme={darkTheme}>
			<CssBaseline />
			<GlobalUserProvider>
				<RouterProvider router={router} />

				<ToastContainer />
			</GlobalUserProvider>
		</ThemeProvider>
	);
}

export default App;
