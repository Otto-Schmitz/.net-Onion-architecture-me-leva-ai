import { toast } from 'react-toastify';

export const TOAST_TYPES = {
  success: 'success',
  warning: 'warning',
  error: 'error',
  info: 'info',
};

export function toastMensagem(mensagem, tipo) {
  toast[tipo](mensagem, {
    position: 'bottom-right',
    autoClose: 5000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
    theme: 'dark',
  });
}
