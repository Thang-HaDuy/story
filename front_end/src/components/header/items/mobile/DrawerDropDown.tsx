import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import MenuItem from '@mui/material/MenuItem';
import Grid from '@mui/material/Grid';
import Link from 'next/link';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';

interface MenuDropDownProps {
    children: React.ReactNode;
    contents: Array<{ href: string; text: string }>;
    isOpen: boolean;
    onToggle: () => void;
}

const DrawerDropDown: React.FC<MenuDropDownProps> = ({ children, contents, isOpen, onToggle }) => {
    return (
        <Box>
            <Box
                onClick={onToggle}
                sx={{
                    display: 'flex',
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    height: '40px',
                    cursor: 'pointer',
                    paddingRight: '24px',
                    paddingLeft: '8px',
                    '&:hover': { backgroundColor: 'rgba(0,0,0,0.5)' },
                }}
            >
                <Typography sx={{ color: 'text.primary', fontSize: '13px' }}>{children}</Typography>
                <KeyboardArrowDownIcon sx={{ color: '#b5e745' }} />
            </Box>
            <Box
                sx={{
                    maxHeight: isOpen ? '900px' : '0px',
                    opacity: isOpen ? 1 : 0,
                    overflow: 'hidden',
                    transition: 'max-height 0.3s ease, opacity 0.3s ease',
                }}
            >
                <Grid container sx={{ backgroundColor: 'rgba(0,0,0,.4)' }}>
                    {contents.map((content, index) => (
                        <Grid item xs={6} key={index}>
                            <MenuItem sx={{ padding: '8px 16px', minHeight: 'auto' }}>
                                <Box
                                    component={Link}
                                    href={`/bang-xep-hang/${content.href}`}
                                    sx={{ textDecoration: 'none', width: '100%' }}
                                >
                                    <Typography
                                        sx={{
                                            color: 'text.primary',
                                            fontSize: '11px',
                                            '&:hover': { opacity: '0.5' },
                                        }}
                                    >
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

export default DrawerDropDown;
