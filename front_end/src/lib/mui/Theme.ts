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
            main: '#0f1416',
        },
    },
});

export default theme;
