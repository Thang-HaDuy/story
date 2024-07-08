import React from 'react';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';

import { Item } from '@/components/header/items/menu/ItemDropdown';
import Itemdropdown from '@/components/header/items/menu/ItemDropdown';

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
                    zIndex: 50,
                    padding: '8px 0',
                    borderTop: '3px solid #b5e745',
                    top: '100%',
                    left: '16%',
                    width: '400px',
                }}
            >
                <Grid container sx={{ maxWidth: '400px' }}>
                    {contents.map((content, index) => (
                        <Itemdropdown key={index} content={content} />
                    ))}
                </Grid>
            </Box>
        </Box>
    );
};

export default MenuDropDown;
