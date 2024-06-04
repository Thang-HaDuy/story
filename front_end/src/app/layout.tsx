import Footer from '@/components/footer/Footer';
import Header from '@/components/header/Header';
import { MuiProvider } from '@/lib/mui/MuiProvider';
import { Providers } from '@/lib/redux/StoreProvider';
import { Box } from '@mui/material';

// <body style={{ backgroundColor: '#263238' }}>

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
                        <Box>
                            <Header />
                            {children}
                            <Footer />
                        </Box>
                    </MuiProvider>
                </Providers>
            </body>
        </html>
    );
};

export default RootLayout;
