import React from 'react';
import Box from '@mui/material/Box';
import Link from 'next/link';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import MenuItem from '@mui/material/MenuItem';

export interface Item {
    text: string;
    href: string;
}
const Itemdropdown = ({ content }: { content: Item }) => {
    return (
        <Grid item md={4}>
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
    );
};

export default Itemdropdown;
