import Box from '@mui/material/Box';
import Link from 'next/link';

const JoinGround = () => {
    return (
        <Box component={Link} href={'/login'} sx={{ display: 'flex', justifyContent: 'center' }}>
            <Box component="img" src={'/join-ground.gif'} alt="join ground anime" />
        </Box>
    );
};

export default JoinGround;
