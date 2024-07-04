import SlideAnimeTop from '@/components/content/slide-anime-top/SlideAnimeTop';
import Box from '@mui/material/Box';

export const metadata = {
    title: 'Anime Vietsub Online',
};

const Home = () => {
    return (
        <Box sx={{ flexGrow: '1', width: '100%', maxWidth: '825px', paddingRight: '20px' }}>
            <SlideAnimeTop />
        </Box>
    );
};

export default Home;
