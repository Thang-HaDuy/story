import React from 'react';
import Button from '@mui/material/Button';
import Link from 'next/link';
import UserDropdown from './UserDropDown';
import Box from '@mui/material/Box';

const User = () => {
    const isLogin = false;

    return isLogin ? (
        <Box
            sx={{
                display: { xs: 'none', md: 'inline-flex' },
                alignItems: 'center',
                backgroundColor: 'background.paper',
            }}
        >
            <UserDropdown />
        </Box>
    ) : (
        <Button
            sx={{
                display: { xs: 'none', md: 'block' },
                lineHeight: '2.2',
                padding: '6px 13px',
                backgroundColor: '#b71c1c',
                color: 'white',
                marginLeft: '10px',
            }}
            component={Link}
            href="/login"
        >
            Đăng Nhập
        </Button>
    );
};

export default User;
