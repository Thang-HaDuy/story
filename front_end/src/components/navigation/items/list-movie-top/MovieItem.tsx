import Rating from '@/components/ui/Rating';
import SelectHover from '@/components/ui/SelectHover';
import TotalEpisode from '@/components/ui/TotalEpisode';
import Link from 'next/link';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import ImageMovie from '@/components/ui/ImageMovie';

export interface ITutorialStep {
    label: string;
    imgPath: string;
    text: string;
    episode: number;
    rating: number;
    className: string;
}
const MovieItem = ({ step }: { step: ITutorialStep }) => {
    return (
        <Box component={Link} href={'/'}>
            <Box
                sx={{
                    marginX: '9.6px',
                    position: 'relative',
                    '&:hover': {
                        [`& .${step.className}`]: { display: 'flex' },
                    },
                }}
            >
                <ImageMovie src={step.imgPath} alt={step.label} />
                <Typography
                    sx={{
                        color: '#fff',
                        zIndex: '5',
                        position: 'absolute',
                        bottom: '0px',
                        left: '0',
                        right: '0',
                        padding: '10px',
                        paddingTop: '50px',
                        fontSize: '12px',
                        fontWeight: '400',
                        lineHeight: '16px',
                        textAlign: 'center',
                        background: 'linear-gradient(to bottom,rgba(0,0,0,0) 0,rgba(0,0,0,.65) 100%)',
                    }}
                >
                    {step.text}
                </Typography>
                <TotalEpisode episode={step.episode} />
                <Rating number={step.rating} />
                <SelectHover className={step.className} />
            </Box>
        </Box>
    );
};

export default MovieItem;
