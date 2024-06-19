import Footer from '@/components/footer/Footer';
import Header from '@/components/header/Header';
import { MuiProvider } from '@/lib/mui/MuiProvider';
import ReduxProviders from '@/lib/redux/StoreProvider';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';
import Announcement from '@/components/navigation/announcement/Announcement';
import ListMovieTop from '@/components/navigation/list-movie-top/ListMovieTop';
import Sidebar from '@/components/sidebar/Sidebar';

export const metadata = {
    title: 'Anime Vietsub Online',
};

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
                        <Container sx={{ padding: { xs: '0', md: '10px 20px' } }}>
                            <Box
                                sx={{
                                    backgroundColor: 'background.paper',
                                    padding: '18px',
                                }}
                            >
                                <Announcement />
                                <ListMovieTop />
                                <Box sx={{ display: { xs: 'flex' } }}>
                                    <Box sx={{ flexGrow: '1' }}>{children}</Box>
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

export default RootLayout;
