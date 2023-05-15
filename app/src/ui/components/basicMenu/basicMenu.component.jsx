import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import * as React from 'react';

import AddIcon from '@mui/icons-material/Add';
import MenuIcon from '@mui/icons-material/Menu';
import { ListItemIcon } from '@mui/material';
import { Link } from 'react-router-dom';
import './basicMenu.style.css';
export function BasicMenu() {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div className="menu-lateral">
      <Button
        id="basic-button"
        aria-controls={open ? 'basic-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
        onClick={handleClick}
      >
        <MenuIcon />
      </Button>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          'aria-labelledby': 'basic-button',
        }}
      >
        <MenuItem onClick={handleClose}>
          <Link to="/passenger/create">
            <ListItemIcon>
              <AddIcon fontSize="small" />
            </ListItemIcon>
            Incluir Passageiro
          </Link>
        </MenuItem>
        <MenuItem onClick={handleClose}>
          <Link to="/driver/create">
            <ListItemIcon>
              <AddIcon fontSize="small" />
            </ListItemIcon>
            Incluir Motorista
          </Link>
        </MenuItem>
      </Menu>
    </div>
  );
}
