'use client';

import React, { useState } from 'react';
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/swiper-bundle.css';
import IconButton from '@mui/material/IconButton';
import Box from '@mui/material/Box';
import KeyboardArrowRight from '@mui/icons-material/KeyboardArrowRight';
import KeyboardArrowLeft from '@mui/icons-material/KeyboardArrowLeft';
import MovieItem, { ITutorialStep } from './item/MovieItem';

const ListMovieTop: React.FC = () => {
    const tutorialSteps: ITutorialStep[] = [
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect31',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect32',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect33',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect34',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect35',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect36',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect37',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect38',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect39',
        },
    ];

    const breakpoints = {
        150: {
            slidesPerView: 2,
        },
        467: {
            slidesPerView: 4,
        },
        785: {
            slidesPerView: 6,
        },
        1005: {
            slidesPerView: 8,
        },
    };

    const [swiper, setSwiper] = useState<any>(null);

    const handleNext = () => {
        if (swiper) swiper.slideNext();
    };

    const handleBack = () => {
        if (swiper) swiper.slidePrev();
    };

    return (
        <Box sx={{ position: 'relative', maxWidth: '100%', flexGrow: 1, marginBottom: '20px', borderRadius: '3px' }}>
            <Box
                component={Swiper}
                sx={{ marginX: '-9.6px' }}
                onSwiper={setSwiper}
                breakpoints={breakpoints}
                loop={true}
            >
                {tutorialSteps.map((step, index) => (
                    <SwiperSlide key={index}>
                        <MovieItem step={step} />
                    </SwiperSlide>
                ))}
            </Box>

            <IconButton
                sx={{
                    position: 'absolute',
                    zIndex: '10',
                    height: '31.5px',
                    width: '25px',
                    borderRadius: 'inherit',
                    marginLeft: '-1.5px',
                    top: '50%',
                    left: 0,
                    transform: 'translateY(-50%)',
                    backgroundColor: '#f62f39',
                    '&:hover': { backgroundColor: '#f62f39' },
                }}
                size="small"
                onClick={handleBack}
            >
                <KeyboardArrowLeft />
            </IconButton>
            <IconButton
                sx={{
                    position: 'absolute',
                    zIndex: '10',
                    height: '31.5px',
                    width: '25px',
                    borderRadius: 'inherit',
                    marginRight: '-1.5px',
                    top: '50%',
                    right: 0,
                    transform: 'translateY(-50%)',
                    backgroundColor: '#f62f39',
                    '&:hover': { backgroundColor: '#f62f39' },
                }}
                size="small"
                onClick={handleNext}
            >
                <KeyboardArrowRight />
            </IconButton>
        </Box>
    );
};

export default ListMovieTop;
