import { MuiProvider } from '@/lib/mui/MuiProvider';
import { Providers } from '@/lib/redux/StoreProvider';

const RootLayout = ({ children }: { children: React.ReactNode }) => {
    return (
        <html lang="en">
            <head>
                <link rel="preconnect" href="https://fonts.googleapis.com" />
                <link rel="preconnect" href="https://fonts.gstatic.com" crossOrigin="anonymous" />
                <link
                    rel="stylesheet"
                    href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;600;700&display=swap"
                />
                <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            </head>
            <body>
                <Providers>
                    <MuiProvider>{children}</MuiProvider>
                </Providers>
            </body>
        </html>
    );
};

export default RootLayout;
