import { Box } from '@mui/material';
import Announcement from './items/announcement/Announcement';
import ListMovieTop from './items/list-movie-top/ListMovieTop';

const Navigation = () => {
    return (
        <Box>
            <Announcement />
            <ListMovieTop />
        </Box>
    );
};

export default Navigation;
