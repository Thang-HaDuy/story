'use client';

import * as React from 'react';
import Drawer from '@mui/material/Drawer';
import MenuIcon from '@mui/icons-material/Menu';
import { Box } from '@mui/material';
import MenuDrawer from './MenuDrawer';

const ButtonMobile = () => {
    const [open, setOpen] = React.useState(false);

    const toggleDrawer = (newOpen: boolean) => () => {
        setOpen(newOpen);
    };

    return (
        <Box sx={{ display: { xs: 'flex', md: 'none' }, marginLeft: '10px' }}>
            <MenuIcon
                sx={{
                    width: '46px',
                    height: '46px',
                    backgroundColor: '#b71c1c',
                    padding: '8px',
                    borderRadius: '3px',
                }}
                onClick={toggleDrawer(true)}
            />
            <Drawer open={open} onClose={toggleDrawer(false)}>
                <MenuDrawer />
            </Drawer>
        </Box>
    );
};

export default ButtonMobile;
