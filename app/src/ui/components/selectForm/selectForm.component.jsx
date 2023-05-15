import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';

export function SelectForm({ handleChange, label, value, name, options }) {
  return (
    <FormControl>
      <InputLabel id="demo-simple-select-label">{label}</InputLabel>
      <Select
        labelId="demo-simple-select-label"
        id="demo-simple-select"
        value={value}
        label="Age"
        onChange={handleChange}
        name={name}
        sx={{ width: '100%' }}
        required
      >
        <MenuItem disabled></MenuItem>
        {options.map((option, index) => {
          return (
            <MenuItem key={index} value={option}>
              {option}
            </MenuItem>
          );
        })}
      </Select>
    </FormControl>
  );
}
