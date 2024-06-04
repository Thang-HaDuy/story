import React from 'react';
import Box from '@mui/material/Box';
import Link from 'next/link';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import MenuItem from '@mui/material/MenuItem';

import { Item } from './MenuItem';

interface MenuDropDownProps {
    children: React.ReactNode;
    contents: Item[];
    className: string;
}
const MenuDropDown: React.FC<MenuDropDownProps> = ({ children, contents, className }) => {
    return (
        <Box
            display="inline-flex"
            position="relative"
            sx={{
                '&:hover': {
                    [`& .${className}`]: { display: 'block' },
                    '&::after': { display: 'block' },
                },
                '&::after': {
                    content: '""',
                    position: 'absolute',
                    display: 'none',
                    borderLeft: ' 5px solid transparent',
                    borderRight: ' 5px solid transparent',
                    borderBottom: ' 5px solid #b5e745',
                    top: '85%',
                    left: '40%',
                },
            }}
        >
            {children}
            <Box
                className={className}
                sx={{
                    position: 'absolute',
                    backgroundColor: 'white',
                    boxShadow: 3,
                    display: 'none',
                    zIndex: 1,
                    padding: '8px 0',
                    borderTop: '3px solid #b5e745',
                    top: '100%',
                    left: '16%',
                    width: '400px',
                }}
            >
                <Grid container sx={{ maxWidth: '400px' }}>
                    {contents.map((content, index) => (
                        <Grid item md={4} key={index}>
                            <MenuItem sx={{ padding: '8px 16px' }}>
                                <Box
                                    component={Link}
                                    href={`/bang-xep-hang/${content.href}`}
                                    sx={{ textDecoration: 'none', width: '100%' }}
                                >
                                    <Typography sx={{ color: '#333', fontSize: '13px', '&:hover': { opacity: '0.5' } }}>
                                        {content.text}
                                    </Typography>
                                </Box>
                            </MenuItem>
                        </Grid>
                    ))}
                </Grid>
            </Box>
        </Box>
    );
};

export default MenuDropDown;
