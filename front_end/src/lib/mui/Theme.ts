import { createTheme } from '@mui/material/styles';

// Create a theme instance.
const theme = createTheme({
    typography: {
        fontFamily: 'Alata, sans-serif',
        fontSize: 13,
    },
    palette: {
        mode: 'dark',
        primary: {
            main: '#fff',
        },
        background: {
            default: '#263238',
            paper: '#0f1416',
        },
        text: {
            primary: '#fff',
            secondary: '#fff',
        },
    },
    components: {
        MuiButton: {
            styleOverrides: {
                root: {
                    textTransform: 'none',
                },
            },
        },
        MuiOutlinedInput: {
            styleOverrides: {
                root: {
                    '&.Mui-focused': {
                        '& .MuiOutlinedInput-notchedOutline': {
                            borderWidth: '1px',
                        },
                    },
                },
            },
        },
    },

    breakpoints: {
        values: {
            xs: 0,
            sm: 600,
            md: 993,
            lg: 1200,
            xl: 1536,
        },
    },
});

export default theme;
