import React from 'react';
import DrawerDropDown from './DrawerDropDown';
import { seasion, theLoai, topAnime } from '@/components/header/items/menu/MenuItem';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Link from 'next/link';
import UserDropdown from '@/components/header/items/user/UserDropDown';

const MenuDrawer: React.FC = () => {
    const [openDropdown, setOpenDropdown] = React.useState<string | null>(null);

    let isLogin: boolean = true;

    const handleToggle = (dropdownName: string) => {
        setOpenDropdown((prev) => (prev === dropdownName ? null : dropdownName));
    };

    return (
        <Box
            sx={{
                maxWidth: '270px',
                minWidth: '235px',
                display: 'flex',
                flexDirection: 'column',
                padding: '16px',
                height: '100%',
                backgroundColor: 'rgba(15,20,22,0.9)',
                backgroundImage: 'none',
            }}
        >
            <Box
                sx={{
                    backgroundColor: 'background.paper',
                    display: 'flex',
                    justifyContent: isLogin ? 'flex-end' : 'center',
                    height: '78px',
                    alignItems: 'center',
                    marginBottom: '16px',
                }}
            >
                {isLogin ? (
                    <Box
                        sx={{
                            display: { xs: 'inline-flex', md: 'none' },
                            alignItems: 'center',
                            marginRight: '40px',
                            backgroundColor: 'background.paper',
                        }}
                    >
                        <UserDropdown />
                    </Box>
                ) : (
                    <Button sx={{ height: '40px', width: '200px', backgroundColor: '#b71c1c' }}>Đăng Nhập</Button>
                )}
            </Box>
            <Box sx={{ marginX: '-16px' }}>
                <Box
                    sx={{
                        textDecoration: 'none',
                        color: 'text.primary',
                        fontSize: '13px',
                        padding: '0 8px',
                        height: '40px',
                        display: 'flex',
                        alignItems: 'center',
                        '&:hover': { backgroundColor: 'rgba(0,0,0,0.5)' },
                    }}
                    component={Link}
                    href={'/'}
                >
                    TRANG CHỦ
                </Box>
                <DrawerDropDown
                    contents={seasion}
                    isOpen={openDropdown === 'SEASION'}
                    onToggle={() => handleToggle('SEASION')}
                >
                    SEASION
                </DrawerDropDown>
                <DrawerDropDown
                    contents={topAnime}
                    isOpen={openDropdown === 'TOP ANIME'}
                    onToggle={() => handleToggle('TOP ANIME')}
                >
                    TOP ANIME
                </DrawerDropDown>
                <DrawerDropDown
                    contents={theLoai}
                    isOpen={openDropdown === 'THỂ LOẠI'}
                    onToggle={() => handleToggle('THỂ LOẠI')}
                >
                    THỂ LOẠI
                </DrawerDropDown>
                <Box
                    sx={{
                        textDecoration: 'none',
                        color: 'text.primary',
                        fontSize: '13px',
                        padding: '0 8px',
                        height: '40px',
                        display: 'flex',
                        alignItems: 'center',
                        '&:hover': { backgroundColor: 'rgba(0,0,0,0.5)' },
                    }}
                    component={Link}
                    href={'/'}
                >
                    THƯ VIỆN
                </Box>
                <Box
                    sx={{
                        textDecoration: 'none',
                        color: 'text.primary',
                        fontSize: '13px',
                        padding: '0 8px',
                        height: '40px',
                        display: 'flex',
                        alignItems: 'center',
                        '&:hover': { backgroundColor: 'rgba(0,0,0,0.5)' },
                    }}
                    component={Link}
                    href={'/'}
                >
                    LỊCH CHIẾU
                </Box>
            </Box>
        </Box>
    );
};

export default MenuDrawer;
