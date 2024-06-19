import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Link from 'next/link';
import TitleSidebar from './TitleSidebar';

const RandomAnime = () => {
    return (
        <Box
            sx={{
                padding: '10px',
                marginBottom: '20px',
                backgroundColor: '#181d1f',
                borderRadius: '3px',
            }}
        >
            <TitleSidebar content={'Hôm này bạn xem gì?'}>
                <></>
            </TitleSidebar>

            <Typography sx={{ color: '#78909c', fontSize: '13px', fontWeight: '300', marginBottom: '16px' }}>
                Nếu bạn buồn phiền không biết xem gì hôm nay. Hãy để chúng tôi chọn cho bạn
            </Typography>
            <Link href="login">
                <Button
                    sx={{ width: '190px', height: '40px', backgroundColor: '#b71c1c', borderRadius: '3px' }}
                    startIcon={<PlayArrowIcon />}
                >
                    Xem Anime Ngẫu Nhiên
                </Button>
            </Link>
        </Box>
    );
};

export default RandomAnime;
