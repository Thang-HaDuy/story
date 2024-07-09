import Footer from '@/components/footer/Footer';
import Header from '@/components/header/Header';
import MuiProvider from '@/lib/mui/MuiProvider';
import ReduxProviders from '@/lib/redux/StoreProvider';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';
import Sidebar from '@/components/sidebar/Sidebar';
import Navigation from '@/components/navigation/Navigation';
import Grid from '@mui/material/Grid';

const RootLayout = ({ children }: { children: React.ReactNode }) => {
    return (
        <html lang="en">
            <head>
                <link rel="preconnect" href="https://fonts.googleapis.com" />
                <link rel="preconnect" href="https://fonts.gstatic.com" crossOrigin="anonymous" />
                <link
                    href="https://fonts.googleapis.com/css2?family=Alata:wght@300;400;500;600;700&display=swap"
                    rel="stylesheet"
                ></link>
                <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            </head>
            <body>
                <ReduxProviders>
                    <MuiProvider>
                        <Header />
                        <Container sx={{ padding: { xs: '0', md: '13px 20px' } }}>
                            <Box
                                sx={{
                                    backgroundColor: 'background.paper',
                                    padding: '18px',
                                }}
                            >
                                <Navigation />
                                <Grid container>
                                    <Grid item xs={12} md={8.5}>
                                        {children}
                                    </Grid>
                                    <Grid item xs={12} md={3.5}>
                                        <Sidebar />
                                    </Grid>
                                </Grid>
                            </Box>
                        </Container>
                        <Footer />
                    </MuiProvider>
                </ReduxProviders>
            </body>
        </html>
    );
};

export default RootLayout;

const RootLayouts = ({ children }: { children: React.ReactNode }) => {
    return (
        <html lang="en">
            <head>
                <link rel="preconnect" href="https://fonts.googleapis.com" />
                <link rel="preconnect" href="https://fonts.gstatic.com" crossOrigin="anonymous" />
                <link
                    href="https://fonts.googleapis.com/css2?family=Alata:wght@300;400;500;600;700&display=swap"
                    rel="stylesheet"
                ></link>
                <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            </head>
            <body>
                <ReduxProviders>
                    <MuiProvider>
                        <Header />
                        <Container sx={{ padding: { xs: '0', md: '13px 20px' } }}>
                            <Box
                                sx={{
                                    backgroundColor: 'background.paper',
                                    padding: '18px',
                                }}
                            >
                                <Navigation />
                                <Box sx={{ display: { xs: 'flex' }, flexDirection: { xs: 'column', md: 'row' } }}>
                                    {children}
                                    <Sidebar />
                                </Box>
                            </Box>
                        </Container>
                        <Footer />
                    </MuiProvider>
                </ReduxProviders>
            </body>
        </html>
    );
};
