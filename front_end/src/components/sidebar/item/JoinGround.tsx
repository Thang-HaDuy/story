import Box from '@mui/material/Box';
import Link from 'next/link';

const JoinGround = () => {
    return (
        <Box component={Link} href={'/login'}>
            <Box component="img" sx={{ width: '100%' }} src={'/join-ground.gif'} alt="join ground anime" />
        </Box>
    );
};

export default JoinGround;
