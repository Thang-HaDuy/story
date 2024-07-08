import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Link from 'next/link';
import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import InforList, { IInforItem } from '@/components/ui/InforList';
import VideocamIcon from '@mui/icons-material/Videocam';
import MovieIcon from '@mui/icons-material/Movie';
import PersonIcon from '@mui/icons-material/Person';
import React from 'react';

export interface IStep {
    label: string;
    imgPath: string;
    name: string;
    detail: string;
    episode: number;
    author: string;
    rating: number;
    className: string;
    categories: string[];
    info: IInforItem;
}

const SlideItem = ({ step }: { step: IStep }) => {
    return (
        <Box sx={{ position: 'relative' }}>
            <Box component={Link} href={'/'}>
                <Box
                    component="img"
                    sx={{
                        maxHeight: '350px',
                        width: '100%',
                        display: 'block',
                        overflow: 'hidden',
                        objectFit: 'cover',
                        borderRadius: '3px',
                    }}
                    src={step.imgPath}
                    alt={step.name}
                />
            </Box>
            <Box
                sx={{
                    backgroundColor: 'rgba(0,0,0,.4)',
                    width: '50%',
                    minWidth: '450px',
                    height: '350px',
                    position: 'absolute',
                    top: '0',
                    left: '0',
                    bottom: '0',
                    padding: '20px',
                }}
            >
                <Box component={Link} href={'/'} sx={{ textDecoration: 'none' }}>
                    <Typography
                        sx={{
                            marginBottom: '11px',
                            fontSize: '30px',
                            fontWeight: '300',
                            lineHeight: '30px',
                            color: '#fff',
                        }}
                    >
                        {step.name}
                    </Typography>
                </Box>
                <InforList item={step.info} />
                <Typography
                    sx={{
                        marginBottom: '9.6px',
                        opacity: '0.8',
                        fontSize: '14px',
                        fontWeight: '300',
                        lineHeight: '21px',
                    }}
                >
                    {step.detail}
                </Typography>
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                    <VideocamIcon sx={{ fontSize: '16px', color: '#b5e745', marginRight: '6.4px' }} />
                    <Box
                        sx={{
                            opacity: '0.8',
                            fontSize: '12px',
                            fontWeight: '700',
                            lineHeight: '22px',
                            marginRight: '3px',
                        }}
                        component="span"
                    >
                        Studio:
                    </Box>
                    <Box sx={{ fontSize: '12px', fontWeight: '300', lineHeight: '22px' }} component="span">
                        {step.author}
                    </Box>
                </Box>
                <Box sx={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
                    <MovieIcon sx={{ fontSize: '16px', color: '#b5e745', marginRight: '6.4px' }} />
                    <Box
                        sx={{
                            opacity: '0.8',
                            fontSize: '12px',
                            fontWeight: '700',
                            lineHeight: '22px',
                            marginRight: '3px',
                        }}
                        component="span"
                    >
                        Thể Loại:
                    </Box>
                    {step.categories.map((category, index) => (
                        <Box
                            key={index}
                            sx={{
                                fontSize: '12px',
                                fontWeight: '300',
                                lineHeight: '22px',
                                textDecoration: 'none',
                                color: 'white',
                                marginRight: '3px',
                            }}
                            component={Link}
                            href={'/'}
                        >
                            {category},
                        </Box>
                    ))}
                </Box>
                <Box sx={{ paddingBottom: '10px' }}>
                    {[1, 2, 3, 4, 5].map((number, index) => (
                        <PersonIcon
                            key={index}
                            sx={{
                                fontSize: '25px',
                                marginRight: '10px',
                                backgroundColor: 'rgba(8,8,10,.6)',
                                borderRadius: '50%',
                                padding: '10px',
                            }}
                        />
                    ))}
                </Box>
                <Button
                    sx={{
                        height: '40px',
                        backgroundColor: '#b71c1c',
                        borderRadius: '3px',
                        paddingX: '16px',
                    }}
                    startIcon={<PlayArrowIcon />}
                >
                    Xem Anime
                </Button>
            </Box>
        </Box>
    );
};

export default SlideItem;
