import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import StarIcon from '@mui/icons-material/Star';

interface IRating {
    number: number;
}
const Rating: React.FC<IRating> = ({ number }) => {
    return (
        <Box
            sx={{
                display: 'flex',
                color: '#f5ec42',
                backgroundColor: 'rgba(0,0,0,.65)',
                padding: '6px 8px',
                top: '5px',
                zIndex: '5',
                marginLeft: '5px',
                borderRadius: '247px',
                position: 'absolute',
                left: '0',
                alignItems: 'center',
            }}
        >
            <StarIcon sx={{ fontSize: '14px' }} />
            <Typography sx={{ fontSize: '12.35px' }}>{number}</Typography>
        </Box>
    );
};

export default Rating;
