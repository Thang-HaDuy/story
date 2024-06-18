import Footer from '@/components/footer/Footer';
import Header from '@/components/header/Header';
import { MuiProvider } from '@/lib/mui/MuiProvider';
import { Providers } from '@/lib/redux/StoreProvider';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';
import Announcement from '@/components/content/announcement/Announcement';
import ListMovieTop from '@/components/content/list-movie-top/ListMovieTop';

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
                <Providers>
                    <MuiProvider>
                        <Header />
                        <Container sx={{ padding: '10px 20px' }}>
                            <Box
                                sx={{
                                    backgroundColor: 'background.paper',
                                    padding: '18px',
                                }}
                            >
                                <Announcement />
                                <ListMovieTop />
                                <Box sx={{ display: { xs: 'flex' } }}>
                                    {children}
                                    <Box>
                                        <h1>sidebar</h1>
                                    </Box>
                                </Box>
                            </Box>
                        </Container>
                        <Footer />
                    </MuiProvider>
                </Providers>
            </body>
        </html>
    );
};

export default RootLayout;
