import createTheme from '@mui/material/styles/createTheme';

export const ThemeContent = createTheme({
    breakpoints: {
        values: {
            xs: 0,
            sm: 544,
            md: 768,
            lg: 1200,
            xl: 1536,
        },
    },
});
