import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import Link from 'next/link';
import MenuItems from './items/menu/MenuItem';
import User from './items/user/User';
import Search from './items/search/Search';

// <AppBar position="static" sx={{ backgroundColor: '#00000099', backgroundImage: 'none' }}>
const Header = () => {
    return (
        <AppBar position="static">
            <Container>
                <Toolbar disableGutters>
                    <Box sx={{ width: '108px', lineHeight: '0', marginRight: '2rem' }} component={Link} href="/">
                        <img style={{ width: '100%' }} src="/logoz.webp" alt="My Image" />
                    </Box>

                    <MenuItems />

                    <Search />

                    <User />
                </Toolbar>
            </Container>
        </AppBar>
    );
};

export default Header;
