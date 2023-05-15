import { useState } from 'react';

export function useForm(defaulValue) {
  const [inputForm, setInputForm] = useState(defaulValue);

  function handleFormInputs(e) {
    const { value, name } = e.target;
    setInputForm((oldUser) => ({ ...oldUser, [name]: value }));
  }

  return { inputForm, handleFormInputs };
}
