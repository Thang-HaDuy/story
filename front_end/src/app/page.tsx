import AnimeUpdate from '@/components/content/anime-update/AnimeUpdate';
import NominatedAnime from '@/components/content/nominated-anime/NominatedAnime';
import SlideAnimeTop from '@/components/content/slide-anime-top/SlideAnimeTop';
import UpcommingAnime from '@/components/content/upcomming-anime/UpcommingAnime';
import Box from '@mui/material/Box';

export const metadata = {
    title: 'Anime Vietsub Online',
};

const Page = () => {
    return (
        <>
            <SlideAnimeTop />
            <AnimeUpdate />
            <UpcommingAnime />
            <NominatedAnime />
        </>
    );
};

export default Page;
