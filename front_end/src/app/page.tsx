import AnimeUpdate from '@/components/content/anime-update/AnimeUpdate';
import NominatedAnime from '@/components/content/nominated-anime/NominatedAnime';
import SlideAnimeTop from '@/components/content/slide-anime-top/SlideAnimeTop';
import UpcommingAnime from '@/components/content/upcomming-anime/UpcommingAnime';
import Box from '@mui/material/Box';

export const metadata = {
    title: 'Anime Vietsub Online',
};

const Home = () => {
    return (
        <Box sx={{ flexGrow: '1', width: '100%', maxWidth: '825px', paddingRight: '20px' }}>
            <SlideAnimeTop />
            <AnimeUpdate />
            <UpcommingAnime />
            <NominatedAnime />
        </Box>
    );
};

export default Home;
