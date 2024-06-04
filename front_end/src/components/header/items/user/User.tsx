'use client';
import React from 'react';
import Button from '@mui/material/Button';
import Link from 'next/link';
import Avatar from '@mui/material/Avatar';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Badge from '@mui/material/Badge';
import MenuItem from '@mui/material/MenuItem';
import Menu from '@mui/material/Menu';
import NotificationsIcon from '@mui/icons-material/Notifications';
import Tooltip from '@mui/material/Tooltip';

const User = () => {
    const settings = ['Thông tin tài khoản', 'Hộp phim', 'Lịch sử', 'Đăng xuất'];
    const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

    const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElUser(event.currentTarget);
    };

    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };
    const isLogin = false;
    return isLogin ? (
        <>
            <Box sx={{ marginLeft: '10px' }}>
                <Badge variant="dot" color="error">
                    <NotificationsIcon />
                </Badge>
            </Box>
            <Box sx={{ flexGrow: 0, marginLeft: '10px' }}>
                <Tooltip title="Open settings">
                    <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                        <Avatar>N</Avatar>
                    </IconButton>
                </Tooltip>
                <Menu
                    sx={{ mt: '45px' }}
                    id="menu-appbar"
                    anchorEl={anchorElUser}
                    anchorOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    keepMounted
                    transformOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    open={Boolean(anchorElUser)}
                    onClose={handleCloseUserMenu}
                >
                    {settings.map((setting) => (
                        <MenuItem key={setting} onClick={handleCloseUserMenu}>
                            <Typography textAlign="center">{setting}</Typography>
                        </MenuItem>
                    ))}
                </Menu>
            </Box>
        </>
    ) : (
        <>
            <Button
                sx={{
                    display: { xs: 'none', sm: 'block' },
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
        </>
    );
};

export default User;
