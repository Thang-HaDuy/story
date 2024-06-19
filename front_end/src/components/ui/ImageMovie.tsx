import Box from '@mui/material/Box';
import React from 'react';

interface IImageMovie {
    src: string;
    alt: string;
}
const ImageMovie: React.FC<IImageMovie> = ({ src, alt }) => {
    return (
        <Box
            component="img"
            sx={{
                maxHeight: '300px',
                width: '100%',
                display: 'block',
                overflow: 'hidden',
                objectFit: 'cover',
                borderRadius: '3px',
            }}
            src={src}
            alt={alt}
        />
    );
};

export default ImageMovie;
