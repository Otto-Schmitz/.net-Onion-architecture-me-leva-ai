import axios from 'axios';

const BASE_API = 'https://localhost:44316';

export const axiosInstance = axios.create({
  baseURL: BASE_API,
});
