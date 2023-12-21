'use client';

import { AppRouterCacheProvider } from '@mui/material-nextjs/v13-appRouter';
import { CssBaseline, ThemeProvider } from '@mui/material';

import theme from './Theme';

export const MuiProvider = ({ children }: { children: React.ReactNode }) => {
    return (
        <ThemeProvider theme={theme}>
            <AppRouterCacheProvider>
                <CssBaseline />
                {children}
            </AppRouterCacheProvider>
        </ThemeProvider>
    );
};
