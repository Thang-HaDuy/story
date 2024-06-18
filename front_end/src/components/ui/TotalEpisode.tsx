import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import React from 'react';

interface ITotalEpisode {
    episode: number;
}

const TotalEpisode: React.FC<ITotalEpisode> = ({ episode }) => {
    return (
        <Box
            sx={{
                color: '#fff',
                backgroundColor: 'rgba(183,28,28,.9)',
                top: '5px',
                zIndex: '5',
                borderRadius: '50%',
                position: 'absolute',
                right: '10px',
                height: '40px',
                width: '40px',
                textAlign: 'center',
                lineHeight: '1px',
            }}
        >
            <Typography sx={{ fontSize: '10px', marginTop: '3px' }}>Tập</Typography>
            <Typography
                sx={{
                    fontSize: '16px',
                    fontWeight: '700',
                    lineHeight: '1px',
                    marginTop: '6px',
                }}
            >
                {episode}
            </Typography>
        </Box>
    );
};

export default TotalEpisode;
