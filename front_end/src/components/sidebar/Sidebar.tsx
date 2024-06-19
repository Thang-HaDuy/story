import Box from '@mui/material/Box';
import RandomAnime from './item/RandomAnime';
import JoinGround from './item/JoinGround';
import AnimeNewUpdate from './item/anime-new-update/AnimeNewUpdate';
import AnimeHot from './item/anime-hot/AnimeHot';
import SuggestedTagList from './item/suggested-tag-list/SuggestedTagList';

const Sidebar = () => {
    return (
        <Box sx={{ width: '300px', display: { xs: 'none', md: 'block' } }}>
            <RandomAnime />
            <JoinGround />
            <AnimeNewUpdate />
            <AnimeHot />
            <SuggestedTagList />
        </Box>
    );
};

export default Sidebar;
